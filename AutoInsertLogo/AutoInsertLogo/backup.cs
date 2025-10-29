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
        public mainForm()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e) // 워드 파일 생성 버튼, 메인 기능.
        {
            string originalPath = textBox1.Text;

            if (string.IsNullOrEmpty(originalPath) || !File.Exists(originalPath)) //워드파일이 없을시 오류메시지
            {
                MessageBox.Show("유효한 Word 파일을 먼저 업로드해주세요.", "파일 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBox1.Items.Count == 0) //이미지 파일이 없을시 오류메시지
            {
                MessageBox.Show("이미지 파일을 먼저 첨부해주세요.", "이미지 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < listBox1.Items.Count; i++) //업로드된 이미지 파일 수만큼 반복.
            {
                string imagePath = listBox1.Items[i].ToString();  //i 번째 이미지 

                string folder = Path.GetDirectoryName(originalPath);
                string originalFileName = Path.GetFileNameWithoutExtension(originalPath); 
                string extension = Path.GetExtension(originalPath);
                string imageName = Path.GetFileNameWithoutExtension(imagePath);
                string copyPath = Path.Combine(folder, $"{originalFileName}({imageName}){extension}"); //위 네줄에서 구해온 정보로, 파일 명 만들기. 워드이름(이미지이름).docx

                try
                {
                    File.Copy(originalPath, copyPath, true);

                    var wordApp = new Microsoft.Office.Interop.Word.Application();
                    wordApp.Visible = false; //true로 하면 word 창 볼 수 있음
                    var doc = wordApp.Documents.Open(copyPath);

                    // 1. 표지에 로고이미지 삽입
                    var firstPageRange = doc.Sections[1].Range;
                    var inlineShape = firstPageRange.InlineShapes.AddPicture(imagePath); //inline방식으로 로고 삽입
                    var shape = inlineShape.ConvertToShape(); // shape방식으로 변경 (편집 용이)   
                    shape.WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapFront; //텍스트 앞 형식

                    shape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue; // 비율 유지
                    shape.Height = CmToPt(1.2); // 높이 1.2센치 , 임의변경가능
                    //shape.Width=CmToPt(3.5); //너비기준 하고싶은 경우 사용
                    shape.Top = CmToPt(11.2);     // 위쪽 여백, 임의변경 (현재는 솔리드it아이콘 바로 아래.)
                    shape.Left = CmToPt(0);   // 왼쪽 여백 임의변경 (현재는 솔리드it아이콘 바로 아래.)

                    // 2. 머리말 삽입 (표지 제외)
                    var section = doc.Sections[1]; // 두 번째 섹션(페이지) 선택
                    var header = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]; //헤더수정 
                    var inline = header.Range.InlineShapes.AddPicture(imagePath); //로고를 inline방식으로 삽입
                    dynamic headerImage = inline.ConvertToShape(); // shape방식으로 변경 (편집 용이)

                    // 배치 설정
                    headerImage.WrapFormat.Type = Word.WdWrapType.wdWrapBehind; // 텍스트 뒤 형식
                    headerImage.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue; // 이미지 비율 고정

                    headerImage.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionMargin; //가로 정렬 기준을 여백으로 설정.
                    headerImage.Left = (float)Word.WdShapePosition.wdShapeRight;  //가로 위치를 여백 기준 '오른쪽 끝'으로 정렬
                    headerImage.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin; //세로 정렬 기준을 여백으로 설정 
                    headerImage.Top = CmToPt(-2.4); // 세로 위치를 여백 기준 -2.3로 설정.

                    headerImage.Height = CmToPt(0.8); //비율유지, 높이 0.8
                    //header.Image.Width = CmToPt(3.5); //너비 기준으로 하고싶은경우 사용 

                    doc.Save();
                    doc.Close();
                    wordApp.Quit();
                }
                catch (Exception ex)    
                {
                    MessageBox.Show("워드 편집 중 오류 발생:\n" + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            MessageBox.Show("모든 문서 생성을 완료했습니다.");
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
