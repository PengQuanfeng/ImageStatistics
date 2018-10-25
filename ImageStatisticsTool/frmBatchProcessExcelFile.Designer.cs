namespace ImageStatisticsTool
{
    partial class frmProcessExcel
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowns = new System.Windows.Forms.Button();
            this.txtImageFilePath = new System.Windows.Forms.TextBox();
            this.btnProcessExcel = new System.Windows.Forms.Button();
            this.processBar = new System.Windows.Forms.ProgressBar();
            this.procesTime = new System.Windows.Forms.Timer(this.components);
            this.lblExcel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Excel文件夹：";
            // 
            // btnBrowns
            // 
            this.btnBrowns.Location = new System.Drawing.Point(645, 12);
            this.btnBrowns.Name = "btnBrowns";
            this.btnBrowns.Size = new System.Drawing.Size(75, 23);
            this.btnBrowns.TabIndex = 5;
            this.btnBrowns.Text = "浏览";
            this.btnBrowns.UseVisualStyleBackColor = true;
            this.btnBrowns.Click += new System.EventHandler(this.btnBrowns_Click);
            // 
            // txtImageFilePath
            // 
            this.txtImageFilePath.Location = new System.Drawing.Point(110, 12);
            this.txtImageFilePath.Name = "txtImageFilePath";
            this.txtImageFilePath.Size = new System.Drawing.Size(529, 21);
            this.txtImageFilePath.TabIndex = 4;
            // 
            // btnProcessExcel
            // 
            this.btnProcessExcel.Location = new System.Drawing.Point(735, 12);
            this.btnProcessExcel.Name = "btnProcessExcel";
            this.btnProcessExcel.Size = new System.Drawing.Size(75, 23);
            this.btnProcessExcel.TabIndex = 7;
            this.btnProcessExcel.Text = "处理Excel";
            this.btnProcessExcel.UseVisualStyleBackColor = true;
            this.btnProcessExcel.Click += new System.EventHandler(this.btnProcessExcel_Click);
            // 
            // processBar
            // 
            this.processBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processBar.Location = new System.Drawing.Point(12, 42);
            this.processBar.Name = "processBar";
            this.processBar.Size = new System.Drawing.Size(798, 23);
            this.processBar.TabIndex = 8;
            // 
            // procesTime
            // 
            this.procesTime.Tick += new System.EventHandler(this.procesTime_Tick);
            // 
            // lblExcel
            // 
            this.lblExcel.AutoSize = true;
            this.lblExcel.Location = new System.Drawing.Point(13, 79);
            this.lblExcel.Name = "lblExcel";
            this.lblExcel.Size = new System.Drawing.Size(41, 12);
            this.lblExcel.TabIndex = 9;
            this.lblExcel.Text = "label2";
            // 
            // frmProcessExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 100);
            this.Controls.Add(this.lblExcel);
            this.Controls.Add(this.processBar);
            this.Controls.Add(this.btnProcessExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowns);
            this.Controls.Add(this.txtImageFilePath);
            this.MaximumSize = new System.Drawing.Size(838, 139);
            this.MinimumSize = new System.Drawing.Size(838, 139);
            this.Name = "frmProcessExcel";
            this.ShowIcon = false;
            this.Text = "批量处理EXCEL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowns;
        private System.Windows.Forms.TextBox txtImageFilePath;
        private System.Windows.Forms.Button btnProcessExcel;
        private System.Windows.Forms.ProgressBar processBar;
        private System.Windows.Forms.Timer procesTime;
        private System.Windows.Forms.Label lblExcel;
    }
}

