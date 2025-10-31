/*워드의 표지와 머릿말에 이미지를 삽입하여 로고를 추가하는 프로그램입니다. */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word; //Word편집에 사용..

namespace AutoInsertLogo
{
    public partial class mainForm : Form
    {
        public mainForm() //종료/예외 훅 추가
        {
            InitializeComponent();

            Application.ThreadException += (s, e) =>
            {
                try { MessageBox.Show("예상치 못한 오류가 발생했습니다.\n열린 Word 인스턴스를 정리합니다.\n\n" + e.Exception.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch { }
                finally { WordSafe.CleanupAll(killLeftover: true); }
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                try { MessageBox.Show("치명적 오류로 종료합니다.\n열린 Word 인스턴스를 정리합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch { }
                finally { WordSafe.CleanupAll(killLeftover: true); }
            };

            Application.ApplicationExit += (s, e) => { WordSafe.CleanupAll(killLeftover: true); };
            this.FormClosing += (s, e) => { WordSafe.CleanupAll(killLeftover: true); };
        }

        private void button1_Click(object sender, EventArgs e) //파일 찾기 버튼 클릭
        {
            textBox1.Clear();
            openFileDialog1.InitialDirectory = @"C:\"; //초기 디렉토리 설정
            //openFileDialog1.Filter = "Word 파일 (*.docx)|*.docx"; word파일 필터기능.

            if (openFileDialog1.ShowDialog() == DialogResult.OK) //파일 선택시
            {
                string file_path = openFileDialog1.FileName; //오픈한 파일의 경로 선택
                string ext = Path.GetExtension(file_path).ToLower();

                if (ext != ".docx")
                {
                    MessageBox.Show(" Word 파일(.docx)만 선택할 수 있습니다.", "잘못된 파일 형식", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                textBox1.Text = file_path;
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e) //Drag로 파일 첨부 가능, 엔터시
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && Path.GetExtension(files[0]).ToLower() == ".docx") //워드파일일 경우만 드랍가능
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e) //Drag로 파일 첨부 가능, 드랍시
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string ext = Path.GetExtension(files[0]).ToLower();
                if (ext == ".docx") //워드파일일 경우만 드랍가능
                {
                    textBox1.Text = files[0];
                }
                else
                {
                    MessageBox.Show("Word 파일(.docx)만 첨부할 수 있습니다.", "파일 형식 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //로고 추가 버튼
        {
            //openFileDialog1.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"; //파일 필터기능
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Multiselect = true; //한 번에 여러개 첨부 가능.

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;

                foreach (string file in files)
                {
                    string ext = Path.GetExtension(file).ToLower();

                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp")
                    {
                        if (!listBox1.Items.Contains(file))
                        {
                            listBox1.Items.Add(file); //리스트박스에 선택한 이미지 첨부
                        }
                        else
                        { // 중복된 파일
                            MessageBox.Show($"중복된 파일입니다:\n{Path.GetFileName(file)}", "중복 파일", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    { // 잘못된 형식 
                        MessageBox.Show(" PNG, JPG, JPEG, BMP 파일만 업로드할 수 있습니다.", "잘못된 파일 형식", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("파일을 선택하지 않았습니다.");
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e) //드래그로 이미지 첨부 가능, 엔터시
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e) //드래그로 이미지 첨부 가능, 드랍시
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            bool hasInvalidFile = false;

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLower();
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp")
                {
                    if (!listBox1.Items.Contains(file))
                    {
                        listBox1.Items.Add(file);
                    }
                }
                else
                {
                    hasInvalidFile = true;
                }
            }

            if (hasInvalidFile)
            {
                MessageBox.Show("PNG, JPG, JPEG, BMP 파일만 업로드할 수 있습니다.", "잘못된 파일", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string originalPath = textBox1.Text;

            if (string.IsNullOrEmpty(originalPath) || !File.Exists(originalPath))
            {
                MessageBox.Show("유효한 Word 파일을 먼저 업로드해주세요.", "파일 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("이미지 파일을 먼저 첨부해주세요.", "이미지 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Word.Application app = null;

            try
            {
                app = WordSafe.StartApp(visible: false); // 한 번만 띄워서 모든 작업

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string imagePath = listBox1.Items[i].ToString();

                    string folder = Path.GetDirectoryName(originalPath);
                    string originalFileName = Path.GetFileNameWithoutExtension(originalPath);
                    string extension = Path.GetExtension(originalPath);
                    string imageName = Path.GetFileNameWithoutExtension(imagePath);
                    string copyPath = Path.Combine(folder, $"{originalFileName}({imageName}){extension}");

                    Word.Document doc = null;

                    try
                    {
                        File.Copy(originalPath, copyPath, true);

                        doc = WordSafe.OpenDoc(app, copyPath);

                        // === 표지 로고 삽입 (기존 로직) ===
                        var firstPageRange = doc.Sections[1].Range;
                        var inlineShape = firstPageRange.InlineShapes.AddPicture(imagePath);
                        var shape = inlineShape.ConvertToShape();
                        shape.WrapFormat.Type = Word.WdWrapType.wdWrapFront;
                        shape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                        shape.Height = CmToPt(1.2);
                        shape.Top = CmToPt(11.2);
                        shape.Left = CmToPt(0);

                        // === 머리말 삽입: 표지 제외, 기존 로직 ===
                        for (int si = 1; si <= doc.Sections.Count; si++)
                        {
                            var s = doc.Sections[si];
                            try { s.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = false; } catch { }
                            try { s.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage].LinkToPrevious = false; } catch { }
                            try { s.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages].LinkToPrevious = false; } catch { }
                        }

                        doc.Sections[1].PageSetup.DifferentFirstPageHeaderFooter = -1; // true
                        for (int secIdx = 2; secIdx <= doc.Sections.Count; secIdx++)
                            doc.Sections[secIdx].PageSetup.DifferentFirstPageHeaderFooter = 0; // false

                        for (int secIdx = 1; secIdx <= doc.Sections.Count; secIdx++)
                        {
                            var sec = doc.Sections[secIdx];
                            var header = sec.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];

                            var inl = header.Range.InlineShapes.AddPicture(imagePath);
                            dynamic headerImage = inl.ConvertToShape();

                            headerImage.WrapFormat.Type = Word.WdWrapType.wdWrapBehind;
                            headerImage.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;

                            headerImage.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionMargin;
                            headerImage.Left = (float)Word.WdShapePosition.wdShapeRight;
                            headerImage.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
                            headerImage.Top = CmToPt(-2.4);
                            headerImage.Height = CmToPt(0.8);
                        }

                        doc.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"워드 편집 중 오류 발생:\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (doc != null) WordSafe.CloseDoc(doc, Word.WdSaveOptions.wdSaveChanges);
                    }
                }

                MessageBox.Show("모든 문서 생성을 완료했습니다.");
            }
            catch (Exception exAll)
            {
                MessageBox.Show("작업 실행 중 치명적 오류:\n" + exAll.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WordSafe.CleanupAll(killLeftover: true);
            }
        }


        //cm을 microsoft word에서 사용하는 pt로 변환.
        private float CmToPt(double cm)
        {
            return (float)(cm * 28.35);
        }

        private void button4_Click(object sender, EventArgs e) //종료버튼 클릭시 종료.
        {
            this.Close();
        }

        //아래는 편의 기능 구현 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //이미지 미리보기 기능 구현
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedPath = listBox1.SelectedItem.ToString();
                if (File.Exists(selectedPath)) //파일이 존재한다면
                {
                    picLogPreview.Image = Image.FromFile(selectedPath); //이미지 박스에 이미지 표시
                    picLogPreview.SizeMode = PictureBoxSizeMode.Zoom; // 보기 좋게 Zoom
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //이미지 삭제 기능
        {
            if (listBox1.SelectedItem != null)
            {
                int selectedIndex = listBox1.SelectedIndex; //선택한 이미지 index
                listBox1.Items.RemoveAt(selectedIndex); //index에 해당하는 이미지 삭제    

                // 미리보기 지우기 (PictureBox도 초기화)
                picLogPreview.Image = null;
            }
            else
            {
                MessageBox.Show("삭제할 이미지를 먼저 선택해주세요.", "선택 없음", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
