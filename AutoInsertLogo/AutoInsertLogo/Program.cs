using System;
using System.Windows.Forms;

namespace AutoInsertLogo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += (s, e) =>
            {
                try
                {
                    MessageBox.Show(
                        "예상치 못한 오류가 발생했습니다.\n열린 Word 인스턴스를 정리합니다.\n\n" + e.Exception.Message,
                        "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch { }
                finally { WordSafe.CleanupAll(true); }
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                try
                {
                    MessageBox.Show("치명적 오류로 종료합니다.\n열린 Word 인스턴스를 정리합니다.",
                        "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch { }
                finally { WordSafe.CleanupAll(true); }
            };

            Application.ApplicationExit += (s, e) => { WordSafe.CleanupAll(true); };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
