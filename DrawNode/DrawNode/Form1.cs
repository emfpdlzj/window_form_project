using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DrawNode
{
    public partial class DrawNode : Form
    {
        public DrawNode()
        {
            InitializeComponent();
            // 마우스 이벤트 핸들러 등록
            pictureBox.MouseWheel += pictureBox_MouseWheel;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseEnter += pictureBox_MouseEnter;

            pictureBox.Focus();
        }
        List<Node> nodes = new List<Node>();
        bool connectNodes = false;
        bool shouldDraw = false;
        float scale = 1.0f;
        float offsetX = 0f;
        float offsetY = 0f;

        bool isPanning = false;
        bool isFirstPanFrame = false;
        Point lastMousePos;


        private void addFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV 또는 텍스트 파일 (*.csv;*.txt)|*.csv;*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                nodes = LoadNodesFromFile(ofd.FileName);
                pictureBox.Invalidate(); // 다시 그리기 요청
                DrawMiniMap();
            }
        }
        private void txtBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 &&
                    (Path.GetExtension(files[0]).ToLower() == ".csv" || Path.GetExtension(files[0]).ToLower() == ".txt"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }
        private void txtBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string path = files[0];
                txtFilePath.Text = path;
                nodes = LoadNodesFromFile(path);
                shouldDraw = true;
                pictureBox.Invalidate(); // 다시 그리기
                DrawMiniMap();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            shouldDraw = true;  
            pictureBox.Invalidate(); // 다시 그리기 요청
            DrawMiniMap();
        }

        private List<Node> LoadNodesFromFile(string path)
        {
            List<Node> list = new List<Node>();
            foreach (string line in File.ReadAllLines(path))
            {
                var parts = Regex.Split(line.Trim(), @"[\s,]+");
                if (parts.Length >= 2 &&
                    double.TryParse(parts[0], out double x) &&
                    double.TryParse(parts[1], out double y))
                {
                    list.Add(new Node(x, y));
                }
            }
            return list;
        }
        private void chkConnectNodes_CheckedChanged(object sender, EventArgs e)
        {
            connectNodes = chkConnectNodes.Checked;
            pictureBox.Invalidate(); // 다시 그리기 요청
            DrawMiniMap();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (!shouldDraw || nodes.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            g.TranslateTransform(offsetX, offsetY); // 팬 
            g.ScaleTransform(scale, scale); // 줌 

            foreach (var node in nodes)
            {
                g.FillEllipse(Brushes.Black, (float)node.X - 3, (float)node.Y - 3, 6, 6);
            }

            if (connectNodes)
            {
                for (int i = 1; i < nodes.Count; i++)
                {
                    var prev = nodes[i - 1];
                    var curr = nodes[i];
                    g.DrawLine(Pens.Black, (float)prev.X, (float)prev.Y, (float)curr.X, (float)curr.Y);
                }
            }
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            pictureBox.Focus(); 
        }
        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            float zoomFactor = 1.1f;
            float oldScale = scale;

            if (e.Delta > 0)
                scale *= zoomFactor;
            else
                scale /= zoomFactor;

            scale = Math.Max(0.1f, Math.Min(scale, 10f));  // 최소 0.1배, 최대 10배

            // 마우스 위치 기준 줌 (화면 흔들림 방지)
            offsetX = e.X - (e.X - offsetX) * (scale / oldScale);
            offsetY = e.Y - (e.Y - offsetY) * (scale / oldScale);

            lblZoom.Text = $"Zoom : {(int)(scale * 100)} %";

            pictureBox.Invalidate();
            DrawMiniMap();
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isPanning = true;
                lastMousePos = e.Location; 
                pictureBox.Cursor = Cursors.Hand;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning)
            {
               // Console.WriteLine($"[Move] Raw e.X={e.X}, e.Y={e.Y} | last={lastMousePos.X},{lastMousePos.Y} | isPanning={isPanning}");
                int dx = e.X - lastMousePos.X;
                int dy = e.Y - lastMousePos.Y;
               // Console.WriteLine($"[MouseMove] dx: {dx}, dy: {dy}");
                offsetX += dx;
                offsetY += dy;
               // Console.WriteLine($"[MouseMove] offsetX: {offsetX}, offsetY: {offsetY}");
                lastMousePos = e.Location;
                pictureBox.Invalidate();
                DrawMiniMap();
                //  Console.WriteLine($"[MouseMove] lastMousePos: X={lastMousePos.X}, Y={lastMousePos.Y}");
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isPanning = false;
                pictureBox.Cursor = Cursors.Default;
                // Console.WriteLine($"패닝종료");
            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!shouldDraw || nodes.Count == 0)
            {
                MessageBox.Show("먼저 노드를 생성하세요.", "알림");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG 이미지 (*.png)|*.png|JPEG 이미지 (*.jpg)|*.jpg";
                sfd.Title = "저장할 파일 선택";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // PictureBox 크기 기준으로 Bitmap 생성
                    Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                    pictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                    // 확장자에 따라 포맷 선택
                    var ext = Path.GetExtension(sfd.FileName).ToLower();
                    if (ext == ".jpg")
                        bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else
                        bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);

                    MessageBox.Show("저장 완료!", "성공");
                }
            }
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            // 줌/팬 초기화
            scale = 1.0f;
            offsetX = 0f;
            offsetY = 0f;
            // 그래프 초기화
            nodes.Clear();
            shouldDraw = false;
            // UI 초기화
            txtFilePath.Text = "";
            lblZoom.Text = "Zoom: 100%";
            // 다시 그리기
            pictureBox.Invalidate();
            miniMapBox.Image = null;
       }
        private void DrawMiniMap()
        {
            if (nodes.Count == 0 || miniMapBox.Width == 0 || miniMapBox.Height == 0)
                return;

            int mapWidth = miniMapBox.Width;
            int mapHeight = miniMapBox.Height;
            Bitmap bmp = new Bitmap(mapWidth, mapHeight);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                // 메인 뷰 1/10 축소해서 그리기 
                g.TranslateTransform(offsetX * 0.1f, offsetY * 0.1f);
                g.ScaleTransform(scale * 0.1f, scale * 0.1f);
                // 노드 그리기
                foreach (var node in nodes)
                {
                    g.FillEllipse(Brushes.Black, (float)node.X - 3, (float)node.Y - 3, 6, 6);
                }
                // 연결선 그리기
                if (connectNodes)
                {
                    for (int i = 1; i < nodes.Count; i++)
                    {
                        var prev = nodes[i - 1];
                        var curr = nodes[i];
                        g.DrawLine(Pens.Black, (float)prev.X, (float)prev.Y, (float)curr.X, (float)curr.Y);
                    }
                }
                // 빨간 사각형: 현재 메인 화면 시야 영역 
                g.ResetTransform(); // 축소 끝났으므로 좌표계 초기화

                float viewX = (-offsetX / scale) * 0.1f;
                float viewY = (-offsetY / scale) * 0.1f;
                float viewW = pictureBox.Width * 0.1f / scale;
                float viewH = pictureBox.Height * 0.1f / scale;

                using (Pen redPen = new Pen(Color.Red, 1))
                {
                    g.DrawRectangle(redPen, viewX, viewY, viewW, viewH);
                }
            }
            miniMapBox.Image = bmp;
        }

        public class Node
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Node(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
