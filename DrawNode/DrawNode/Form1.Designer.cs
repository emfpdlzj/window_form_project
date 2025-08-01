namespace DrawNode
{
    partial class DrawNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawNode));
            this.addFileBtn = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.chkConnectNodes = new System.Windows.Forms.CheckBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.borderPanel = new System.Windows.Forms.Panel();
            this.lblZoom = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.miniMapBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.borderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapBox)).BeginInit();
            this.SuspendLayout();
            // 
            // addFileBtn
            // 
            this.addFileBtn.BackColor = System.Drawing.SystemColors.Control;
            this.addFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFileBtn.Location = new System.Drawing.Point(12, 11);
            this.addFileBtn.Name = "addFileBtn";
            this.addFileBtn.Size = new System.Drawing.Size(90, 30);
            this.addFileBtn.TabIndex = 0;
            this.addFileBtn.Text = "파일 추가";
            this.addFileBtn.UseVisualStyleBackColor = false;
            this.addFileBtn.Click += new System.EventHandler(this.addFileBtn_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFilePath.Location = new System.Drawing.Point(108, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(884, 29);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(710, 62);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(90, 30);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "저장";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Location = new System.Drawing.Point(901, 62);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(90, 30);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "닫기";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.UseWaitCursor = true;
            // 
            // chkConnectNodes
            // 
            this.chkConnectNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkConnectNodes.AutoSize = true;
            this.chkConnectNodes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkConnectNodes.FlatAppearance.BorderSize = 50;
            this.chkConnectNodes.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkConnectNodes.Location = new System.Drawing.Point(8, 6);
            this.chkConnectNodes.Name = "chkConnectNodes";
            this.chkConnectNodes.Size = new System.Drawing.Size(69, 17);
            this.chkConnectNodes.TabIndex = 4;
            this.chkConnectNodes.Text = "점 연결";
            this.chkConnectNodes.UseVisualStyleBackColor = true;
            this.chkConnectNodes.CheckedChanged += new System.EventHandler(this.chkConnectNodes_CheckedChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Location = new System.Drawing.Point(12, 109);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(1);
            this.pictureBox.Size = new System.Drawing.Size(980, 435);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            this.pictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseWheel);
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createBtn.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createBtn.Location = new System.Drawing.Point(614, 62);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(90, 30);
            this.createBtn.TabIndex = 7;
            this.createBtn.Text = "점 생성";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // borderPanel
            // 
            this.borderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.borderPanel.BackColor = System.Drawing.SystemColors.Control;
            this.borderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderPanel.Controls.Add(this.chkConnectNodes);
            this.borderPanel.Location = new System.Drawing.Point(518, 62);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(90, 30);
            this.borderPanel.TabIndex = 6;
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoom.Location = new System.Drawing.Point(14, 89);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(92, 13);
            this.lblZoom.TabIndex = 8;
            this.lblZoom.Text = "Zoom : 100 %";
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Location = new System.Drawing.Point(806, 62);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(90, 30);
            this.resetBtn.TabIndex = 9;
            this.resetBtn.Text = "초기화";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // miniMapBox
            // 
            this.miniMapBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.miniMapBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.miniMapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miniMapBox.Location = new System.Drawing.Point(786, 445);
            this.miniMapBox.Name = "miniMapBox";
            this.miniMapBox.Size = new System.Drawing.Size(192, 87);
            this.miniMapBox.TabIndex = 10;
            this.miniMapBox.TabStop = false;
            // 
            // DrawNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 556);
            this.Controls.Add(this.miniMapBox);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.borderPanel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.addFileBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrawNode";
            this.Text = "DrawGraph v0.1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.borderPanel.ResumeLayout(false);
            this.borderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addFileBtn;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.CheckBox chkConnectNodes;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Panel borderPanel;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.PictureBox miniMapBox;
    }
}

