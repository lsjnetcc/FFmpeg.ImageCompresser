namespace FFmpeg.ImageCompresser
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvFileCompress = new System.Windows.Forms.ListView();
            this.文件名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.文件大小 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.图片尺寸 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectCompressFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompressFolderPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvFileCompressResult = new System.Windows.Forms.ListView();
            this.压缩文件 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.压缩前大小 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.压缩后大小 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.压缩结果 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectSaveFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaveFolderPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStartCompress = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFailCount = new System.Windows.Forms.Label();
            this.lblSuccessCount = new System.Windows.Forms.Label();
            this.lblWaitCompressFileCount = new System.Windows.Forms.Label();
            this.lblInfomation = new System.Windows.Forms.Label();
            this.gbxChangeSize = new System.Windows.Forms.GroupBox();
            this.cmbChangeType = new System.Windows.Forms.ComboBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkChangeSize = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxChangeSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvFileCompress);
            this.groupBox1.Controls.Add(this.btnSelectCompressFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCompressFolderPath);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1092, 335);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件来源";
            // 
            // lvFileCompress
            // 
            this.lvFileCompress.AllowDrop = true;
            this.lvFileCompress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.文件名称,
            this.文件大小,
            this.图片尺寸});
            this.lvFileCompress.FullRowSelect = true;
            this.lvFileCompress.GridLines = true;
            this.lvFileCompress.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFileCompress.HideSelection = false;
            this.lvFileCompress.Location = new System.Drawing.Point(13, 59);
            this.lvFileCompress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvFileCompress.MultiSelect = false;
            this.lvFileCompress.Name = "lvFileCompress";
            this.lvFileCompress.Size = new System.Drawing.Size(1060, 263);
            this.lvFileCompress.TabIndex = 3;
            this.lvFileCompress.UseCompatibleStateImageBehavior = false;
            this.lvFileCompress.View = System.Windows.Forms.View.Details;
            this.lvFileCompress.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFileCompress_DragDrop);
            this.lvFileCompress.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFileCompress_DragEnter);
            // 
            // 文件名称
            // 
            this.文件名称.Text = "文件名称";
            this.文件名称.Width = 570;
            // 
            // 文件大小
            // 
            this.文件大小.Text = "文件大小";
            this.文件大小.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.文件大小.Width = 100;
            // 
            // 图片尺寸
            // 
            this.图片尺寸.Text = "图片尺寸(宽x高)";
            this.图片尺寸.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.图片尺寸.Width = 120;
            // 
            // btnSelectCompressFolder
            // 
            this.btnSelectCompressFolder.Location = new System.Drawing.Point(975, 24);
            this.btnSelectCompressFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectCompressFolder.Name = "btnSelectCompressFolder";
            this.btnSelectCompressFolder.Size = new System.Drawing.Size(100, 29);
            this.btnSelectCompressFolder.TabIndex = 2;
            this.btnSelectCompressFolder.Text = "浏览";
            this.btnSelectCompressFolder.UseVisualStyleBackColor = true;
            this.btnSelectCompressFolder.Click += new System.EventHandler(this.btnSelectCompressFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择文件夹";
            // 
            // txtCompressFolderPath
            // 
            this.txtCompressFolderPath.Location = new System.Drawing.Point(99, 25);
            this.txtCompressFolderPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCompressFolderPath.Name = "txtCompressFolderPath";
            this.txtCompressFolderPath.Size = new System.Drawing.Size(872, 25);
            this.txtCompressFolderPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvFileCompressResult);
            this.groupBox2.Controls.Add(this.btnSelectSaveFolder);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSaveFolderPath);
            this.groupBox2.Location = new System.Drawing.Point(16, 358);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1092, 312);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存到";
            // 
            // lvFileCompressResult
            // 
            this.lvFileCompressResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.压缩文件,
            this.压缩前大小,
            this.压缩后大小,
            this.压缩结果});
            this.lvFileCompressResult.FullRowSelect = true;
            this.lvFileCompressResult.GridLines = true;
            this.lvFileCompressResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFileCompressResult.HideSelection = false;
            this.lvFileCompressResult.Location = new System.Drawing.Point(13, 60);
            this.lvFileCompressResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvFileCompressResult.MultiSelect = false;
            this.lvFileCompressResult.Name = "lvFileCompressResult";
            this.lvFileCompressResult.Size = new System.Drawing.Size(1060, 240);
            this.lvFileCompressResult.TabIndex = 6;
            this.lvFileCompressResult.UseCompatibleStateImageBehavior = false;
            this.lvFileCompressResult.View = System.Windows.Forms.View.Details;
            // 
            // 压缩文件
            // 
            this.压缩文件.Text = "文件名称";
            this.压缩文件.Width = 423;
            // 
            // 压缩前大小
            // 
            this.压缩前大小.Text = "压缩前大小";
            this.压缩前大小.Width = 100;
            // 
            // 压缩后大小
            // 
            this.压缩后大小.Text = "压缩后大小";
            this.压缩后大小.Width = 100;
            // 
            // 压缩结果
            // 
            this.压缩结果.Text = "压缩结果";
            this.压缩结果.Width = 130;
            // 
            // btnSelectSaveFolder
            // 
            this.btnSelectSaveFolder.Location = new System.Drawing.Point(975, 24);
            this.btnSelectSaveFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectSaveFolder.Name = "btnSelectSaveFolder";
            this.btnSelectSaveFolder.Size = new System.Drawing.Size(100, 29);
            this.btnSelectSaveFolder.TabIndex = 5;
            this.btnSelectSaveFolder.Text = "浏览";
            this.btnSelectSaveFolder.UseVisualStyleBackColor = true;
            this.btnSelectSaveFolder.Click += new System.EventHandler(this.btnSelectSaveFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择文件夹";
            // 
            // txtSaveFolderPath
            // 
            this.txtSaveFolderPath.Location = new System.Drawing.Point(99, 25);
            this.txtSaveFolderPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSaveFolderPath.Name = "txtSaveFolderPath";
            this.txtSaveFolderPath.Size = new System.Drawing.Size(872, 25);
            this.txtSaveFolderPath.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 712);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "压缩进度：";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1008, 696);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 29);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清空任务";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStartCompress
            // 
            this.btnStartCompress.Location = new System.Drawing.Point(900, 696);
            this.btnStartCompress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartCompress.Name = "btnStartCompress";
            this.btnStartCompress.Size = new System.Drawing.Size(100, 29);
            this.btnStartCompress.TabIndex = 4;
            this.btnStartCompress.Text = "开始压缩";
            this.btnStartCompress.UseVisualStyleBackColor = true;
            this.btnStartCompress.Click += new System.EventHandler(this.btnStartCompress_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 678);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "待压缩文件：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 678);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "压缩成功：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 678);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "压缩失败：";
            // 
            // lblFailCount
            // 
            this.lblFailCount.AutoSize = true;
            this.lblFailCount.ForeColor = System.Drawing.Color.Red;
            this.lblFailCount.Location = new System.Drawing.Point(380, 678);
            this.lblFailCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFailCount.Name = "lblFailCount";
            this.lblFailCount.Size = new System.Drawing.Size(15, 15);
            this.lblFailCount.TabIndex = 8;
            this.lblFailCount.Text = "0";
            // 
            // lblSuccessCount
            // 
            this.lblSuccessCount.AutoSize = true;
            this.lblSuccessCount.ForeColor = System.Drawing.Color.Green;
            this.lblSuccessCount.Location = new System.Drawing.Point(255, 678);
            this.lblSuccessCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuccessCount.Name = "lblSuccessCount";
            this.lblSuccessCount.Size = new System.Drawing.Size(15, 15);
            this.lblSuccessCount.TabIndex = 9;
            this.lblSuccessCount.Text = "0";
            // 
            // lblWaitCompressFileCount
            // 
            this.lblWaitCompressFileCount.AutoSize = true;
            this.lblWaitCompressFileCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.lblWaitCompressFileCount.Location = new System.Drawing.Point(127, 678);
            this.lblWaitCompressFileCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWaitCompressFileCount.Name = "lblWaitCompressFileCount";
            this.lblWaitCompressFileCount.Size = new System.Drawing.Size(15, 15);
            this.lblWaitCompressFileCount.TabIndex = 10;
            this.lblWaitCompressFileCount.Text = "0";
            // 
            // lblInfomation
            // 
            this.lblInfomation.AutoSize = true;
            this.lblInfomation.Location = new System.Drawing.Point(101, 712);
            this.lblInfomation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfomation.Name = "lblInfomation";
            this.lblInfomation.Size = new System.Drawing.Size(82, 15);
            this.lblInfomation.TabIndex = 11;
            this.lblInfomation.Text = "未开始压缩";
            // 
            // gbxChangeSize
            // 
            this.gbxChangeSize.Controls.Add(this.cmbChangeType);
            this.gbxChangeSize.Controls.Add(this.txtHeight);
            this.gbxChangeSize.Controls.Add(this.txtWidth);
            this.gbxChangeSize.Controls.Add(this.label8);
            this.gbxChangeSize.Controls.Add(this.label7);
            this.gbxChangeSize.Location = new System.Drawing.Point(476, 678);
            this.gbxChangeSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxChangeSize.Name = "gbxChangeSize";
            this.gbxChangeSize.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxChangeSize.Size = new System.Drawing.Size(417, 55);
            this.gbxChangeSize.TabIndex = 12;
            this.gbxChangeSize.TabStop = false;
            // 
            // cmbChangeType
            // 
            this.cmbChangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChangeType.FormattingEnabled = true;
            this.cmbChangeType.Location = new System.Drawing.Point(285, 24);
            this.cmbChangeType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbChangeType.Name = "cmbChangeType";
            this.cmbChangeType.Size = new System.Drawing.Size(117, 23);
            this.cmbChangeType.TabIndex = 5;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(180, 24);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(95, 25);
            this.txtHeight.TabIndex = 4;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(40, 24);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(95, 25);
            this.txtWidth.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "高";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "宽";
            // 
            // chkChangeSize
            // 
            this.chkChangeSize.AutoSize = true;
            this.chkChangeSize.Location = new System.Drawing.Point(492, 676);
            this.chkChangeSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkChangeSize.Name = "chkChangeSize";
            this.chkChangeSize.Size = new System.Drawing.Size(119, 19);
            this.chkChangeSize.TabIndex = 0;
            this.chkChangeSize.Text = "设置图片缩放";
            this.chkChangeSize.UseVisualStyleBackColor = true;
            this.chkChangeSize.Click += new System.EventHandler(this.ChkChangeSize_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 740);
            this.Controls.Add(this.chkChangeSize);
            this.Controls.Add(this.gbxChangeSize);
            this.Controls.Add(this.lblInfomation);
            this.Controls.Add(this.lblWaitCompressFileCount);
            this.Controls.Add(this.lblSuccessCount);
            this.Controls.Add(this.lblFailCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartCompress);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片批量压缩器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxChangeSize.ResumeLayout(false);
            this.gbxChangeSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCompressFolderPath;
		private System.Windows.Forms.Button btnSelectCompressFolder;
		private System.Windows.Forms.Button btnSelectSaveFolder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSaveFolderPath;
		private System.Windows.Forms.ListView lvFileCompress;
		private System.Windows.Forms.ListView lvFileCompressResult;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnStartCompress;
		private System.Windows.Forms.ColumnHeader 文件名称;
		private System.Windows.Forms.ColumnHeader 压缩文件;
		private System.Windows.Forms.ColumnHeader 压缩结果;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblFailCount;
		private System.Windows.Forms.Label lblSuccessCount;
		private System.Windows.Forms.Label lblWaitCompressFileCount;
		private System.Windows.Forms.ColumnHeader 压缩前大小;
		private System.Windows.Forms.ColumnHeader 压缩后大小;
		private System.Windows.Forms.ColumnHeader 文件大小;
        private System.Windows.Forms.Label lblInfomation;
        private System.Windows.Forms.GroupBox gbxChangeSize;
        private System.Windows.Forms.CheckBox chkChangeSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.ColumnHeader 图片尺寸;
        private System.Windows.Forms.ComboBox cmbChangeType;
    }
}

