/* Word Interop 안전 종료 유틸 (C# 7.3 / .NET Framework 호환)
 * -  띄운 WINWORD 인스턴스/문서만 추적 및 정리
 * - 정상 종료 실패 시, 해당 PID만 최후수단으로 Kill
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace AutoInsertLogo
{
    internal static class WordSafe
    {
        private static readonly List<Word.Document> Docs = new List<Word.Document>();
        private static readonly List<Word.Application> Apps = new List<Word.Application>();
        private static readonly HashSet<int> Pids = new HashSet<int>();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static Word.Application StartApp(bool visible = false)
        {
            // Word 인스턴스 생성
            Word.Application app = new Word.Application();
            app.Visible = visible;
            app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;

            Word.Document temp = null;
            try
            {
                // 일부 환경에서는 Application.Hwnd 가 노출되지 않음
                // → 임시 문서를 열어 ActiveWindow.Hwnd 로 핸들 확보
                temp = app.Documents.Add();
                int winHwnd = app.ActiveWindow.Hwnd;    // Window 핸들(int)
                IntPtr hwnd = new IntPtr(winHwnd);

                uint pid;
                GetWindowThreadProcessId(hwnd, out pid);
                Pids.Add((int)pid);
            }
            catch
            {
                // 혹시 윈도우 핸들 추출 실패해도 앱은 계속 사용 가능
                // (PID 트래킹은 못하지만 정상 종료/COM 릴리즈는 동작)
            }
            finally
            {
                // 임시 문서는 저장 없이 닫기
                if (temp != null)
                {
                    try { temp.Close(Word.WdSaveOptions.wdDoNotSaveChanges); } catch { }
                    try { Marshal.ReleaseComObject(temp); } catch { }
                    temp = null;
                }
            }

            Apps.Add(app);
            return app;
        }


        public static Word.Document OpenDoc(Word.Application app, string path)
        {
            // AddToRecentFiles:false 등 옵션은 필수만 지정하고 나머지는 기본값 사용(호환성↑)
            Word.Document doc = app.Documents.Open(
                path,           // FileName
                ReadOnly: false,
                AddToRecentFiles: false,
                Visible: false
            );
            Docs.Add(doc);
            return doc;
        }

        public static void CloseDoc(Word.Document doc, Word.WdSaveOptions save)
        {
            if (doc == null) return;
            try { doc.Close(save); }
            catch { /* ignore */ }
            finally
            {
                ReleaseCom(doc);
                Docs.Remove(doc);
            }
        }

        public static void QuitApp(Word.Application app)
        {
            if (app == null) return;
            try { app.Quit(Word.WdSaveOptions.wdDoNotSaveChanges); }
            catch { /* ignore */ }
            finally
            {
                ReleaseCom(app);
                Apps.Remove(app);
            }
        }

        public static void CleanupAll(bool killLeftover)
        {
            // (1) 문서 닫기
            for (int i = Docs.Count - 1; i >= 0; i--)
                CloseDoc(Docs[i], Word.WdSaveOptions.wdSaveChanges);

            // (2) 앱 종료
            for (int i = Apps.Count - 1; i >= 0; i--)
                QuitApp(Apps[i]);

            // (3) COM 해제 후 GC 안정화
            RunGcTwice();

            // (4) 남은 PID의 WINWORD만 강제 종료 (Framework는 Kill()만 지원)
            if (killLeftover && Pids.Count > 0)
            {
                Process[] procs = Process.GetProcessesByName("WINWORD");
                foreach (Process p in procs)
                {
                    try
                    {
                        if (Pids.Contains(p.Id))
                            p.Kill(); // entireProcessTree 매개변수 없는 버전
                    }
                    catch { /* ignore */ }
                }
                Pids.Clear();
            }
        }

        private static void ReleaseCom(object o)
        {
            try
            {
                if (o != null && Marshal.IsComObject(o))
                    Marshal.ReleaseComObject(o);
            }
            catch { /* ignore */ }
        }

        private static void RunGcTwice()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
