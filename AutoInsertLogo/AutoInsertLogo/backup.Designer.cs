namespace AutoInsertLogo
{
    partial class mainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.picLogPreview = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOriginManual = new System.Windows.Forms.Label();
            this.btnSearchFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(12, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(721, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 150);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(582, 260);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // picLogPreview
            // 
            this.picLogPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogPreview.BackColor = System.Drawing.Color.White;
            this.picLogPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogPreview.InitialImage = null;
            this.picLogPreview.Location = new System.Drawing.Point(614, 150);
            this.picLogPreview.Name = "picLogPreview";
            this.picLogPreview.Size = new System.Drawing.Size(208, 151);
            this.picLogPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogPreview.TabIndex = 8;
            this.picLogPreview.TabStop = false;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "button5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button5.Location = new System.Drawing.Point(723, 324);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 28);
            this.button5.TabIndex = 10;
            this.button5.Text = global::AutoInsertLogo.Properties.Settings.Default.button5;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "label3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(610, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = global::AutoInsertLogo.Properties.Settings.Default.label3;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "button4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button4.Location = new System.Drawing.Point(723, 370);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 28);
            this.button4.TabIndex = 7;
            this.button4.Text = global::AutoInsertLogo.Properties.Settings.Default.button4;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "button3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button3.Location = new System.Drawing.Point(614, 370);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 28);
            this.button3.TabIndex = 6;
            this.button3.Text = global::AutoInsertLogo.Properties.Settings.Default.button3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "button2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button2.Location = new System.Drawing.Point(614, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = global::AutoInsertLogo.Properties.Settings.Default.button2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "label2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = global::AutoInsertLogo.Properties.Settings.Default.label2;
            // 
            // lbOriginManual
            // 
            this.lbOriginManual.AutoSize = true;
            this.lbOriginManual.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "label1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbOriginManual.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbOriginManual.Location = new System.Drawing.Point(13, 19);
            this.lbOriginManual.Name = "lbOriginManual";
            this.lbOriginManual.Size = new System.Drawing.Size(104, 19);
            this.lbOriginManual.TabIndex = 2;
            this.lbOriginManual.Text = global::AutoInsertLogo.Properties.Settings.Default.label1;
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "button1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnSearchFile.Location = new System.Drawing.Point(743, 48);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(75, 28);
            this.btnSearchFile.TabIndex = 1;
            this.btnSearchFile.Text = global::AutoInsertLogo.Properties.Settings.Default.button1;
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 456);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picLogPreview);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbOriginManual);
            this.Controls.Add(this.btnSearchFile);
            this.Controls.Add(this.textBox1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoInsertLogo.Properties.Settings.Default, "AutoInsertLogo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = global::AutoInsertLogo.Properties.Settings.Default.AutoInsertLogo;
            ((System.ComponentModel.ISupportInitialize)(this.picLogPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearchFile;
        private System.Windows.Forms.Label lbOriginManual;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox picLogPreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
    }
}

