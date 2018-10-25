namespace ImageStatistics
{
    partial class frmImageStatistics
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
            this.tabImage = new System.Windows.Forms.TabControl();
            this.tabOrgionFile = new System.Windows.Forms.TabPage();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDeleteEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDeleteStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblFileName = new System.Windows.Forms.Label();
            this.processBarImport = new System.Windows.Forms.ProgressBar();
            this.btnImprot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowns = new System.Windows.Forms.Button();
            this.txtImageFilePath = new System.Windows.Forms.TextBox();
            this.dgvOrgionView = new System.Windows.Forms.DataGridView();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnExportReportStatistics = new System.Windows.Forms.Button();
            this.btnStoreReportStatistics = new System.Windows.Forms.Button();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDoctorPrice = new System.Windows.Forms.TabPage();
            this.btnSearchDoctorPrice = new System.Windows.Forms.Button();
            this.progressBarDoctorPrice = new System.Windows.Forms.ProgressBar();
            this.btnImportDoctorPrice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrownDoctorPrice = new System.Windows.Forms.Button();
            this.txtDoctorPrice = new System.Windows.Forms.TextBox();
            this.dgvRadiationDoctorPriceDetial = new System.Windows.Forms.DataGridView();
            this.tabDoctorStatistics = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRadiationDoctorPrice = new System.Windows.Forms.DataGridView();
            this.DN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRadiationStoreDoctorPrice = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpRadiationDoctorEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpRadiationDoctorStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnExportRadiationDoctorReport = new System.Windows.Forms.Button();
            this.btnRadiationDoctorReport = new System.Windows.Forms.Button();
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            this.processDoctorPriceTimer = new System.Windows.Forms.Timer(this.components);
            this.tabImage.SuspendLayout();
            this.tabOrgionFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgionView)).BeginInit();
            this.tabStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.tabDoctorPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadiationDoctorPriceDetial)).BeginInit();
            this.tabDoctorStatistics.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadiationDoctorPrice)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadiationStoreDoctorPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // tabImage
            // 
            this.tabImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabImage.Controls.Add(this.tabOrgionFile);
            this.tabImage.Controls.Add(this.tabStatistics);
            this.tabImage.Controls.Add(this.tabDoctorPrice);
            this.tabImage.Controls.Add(this.tabDoctorStatistics);
            this.tabImage.Location = new System.Drawing.Point(0, 0);
            this.tabImage.Name = "tabImage";
            this.tabImage.SelectedIndex = 0;
            this.tabImage.Size = new System.Drawing.Size(1374, 547);
            this.tabImage.TabIndex = 0;
            // 
            // tabOrgionFile
            // 
            this.tabOrgionFile.AutoScroll = true;
            this.tabOrgionFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabOrgionFile.Controls.Add(this.btnDeleteData);
            this.tabOrgionFile.Controls.Add(this.label7);
            this.tabOrgionFile.Controls.Add(this.label8);
            this.tabOrgionFile.Controls.Add(this.dtpDeleteEndTime);
            this.tabOrgionFile.Controls.Add(this.dtpDeleteStartTime);
            this.tabOrgionFile.Controls.Add(this.lblFileName);
            this.tabOrgionFile.Controls.Add(this.processBarImport);
            this.tabOrgionFile.Controls.Add(this.btnImprot);
            this.tabOrgionFile.Controls.Add(this.label1);
            this.tabOrgionFile.Controls.Add(this.btnBrowns);
            this.tabOrgionFile.Controls.Add(this.txtImageFilePath);
            this.tabOrgionFile.Controls.Add(this.dgvOrgionView);
            this.tabOrgionFile.Location = new System.Drawing.Point(4, 22);
            this.tabOrgionFile.Name = "tabOrgionFile";
            this.tabOrgionFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrgionFile.Size = new System.Drawing.Size(1366, 521);
            this.tabOrgionFile.TabIndex = 0;
            this.tabOrgionFile.Text = "源数据";
            this.tabOrgionFile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Location = new System.Drawing.Point(852, 15);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteData.TabIndex = 11;
            this.btnDeleteData.Text = "删除数据";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1162, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(963, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "检查时间：";
            // 
            // dtpDeleteEndTime
            // 
            this.dtpDeleteEndTime.Location = new System.Drawing.Point(1185, 17);
            this.dtpDeleteEndTime.Name = "dtpDeleteEndTime";
            this.dtpDeleteEndTime.Size = new System.Drawing.Size(112, 21);
            this.dtpDeleteEndTime.TabIndex = 8;
            // 
            // dtpDeleteStartTime
            // 
            this.dtpDeleteStartTime.Location = new System.Drawing.Point(1034, 17);
            this.dtpDeleteStartTime.Name = "dtpDeleteStartTime";
            this.dtpDeleteStartTime.Size = new System.Drawing.Size(112, 21);
            this.dtpDeleteStartTime.TabIndex = 7;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.ForeColor = System.Drawing.Color.Red;
            this.lblFileName.Location = new System.Drawing.Point(1317, 22);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 12);
            this.lblFileName.TabIndex = 6;
            // 
            // processBarImport
            // 
            this.processBarImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processBarImport.Location = new System.Drawing.Point(3, 53);
            this.processBarImport.Name = "processBarImport";
            this.processBarImport.Size = new System.Drawing.Size(1362, 23);
            this.processBarImport.TabIndex = 5;
            // 
            // btnImprot
            // 
            this.btnImprot.Location = new System.Drawing.Point(753, 15);
            this.btnImprot.Name = "btnImprot";
            this.btnImprot.Size = new System.Drawing.Size(75, 23);
            this.btnImprot.TabIndex = 4;
            this.btnImprot.Text = "导入数据";
            this.btnImprot.UseVisualStyleBackColor = true;
            this.btnImprot.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "导入影像文件：";
            // 
            // btnBrowns
            // 
            this.btnBrowns.Location = new System.Drawing.Point(653, 15);
            this.btnBrowns.Name = "btnBrowns";
            this.btnBrowns.Size = new System.Drawing.Size(75, 23);
            this.btnBrowns.TabIndex = 2;
            this.btnBrowns.Text = "浏览";
            this.btnBrowns.UseVisualStyleBackColor = true;
            this.btnBrowns.Click += new System.EventHandler(this.btnBrowns_Click);
            // 
            // txtImageFilePath
            // 
            this.txtImageFilePath.Location = new System.Drawing.Point(118, 15);
            this.txtImageFilePath.Name = "txtImageFilePath";
            this.txtImageFilePath.Size = new System.Drawing.Size(529, 21);
            this.txtImageFilePath.TabIndex = 1;
            // 
            // dgvOrgionView
            // 
            this.dgvOrgionView.AllowUserToAddRows = false;
            this.dgvOrgionView.AllowUserToDeleteRows = false;
            this.dgvOrgionView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrgionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrgionView.Location = new System.Drawing.Point(3, 76);
            this.dgvOrgionView.Name = "dgvOrgionView";
            this.dgvOrgionView.ReadOnly = true;
            this.dgvOrgionView.RowTemplate.Height = 23;
            this.dgvOrgionView.Size = new System.Drawing.Size(1362, 440);
            this.dgvOrgionView.TabIndex = 0;
            // 
            // tabStatistics
            // 
            this.tabStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabStatistics.Controls.Add(this.label3);
            this.tabStatistics.Controls.Add(this.label2);
            this.tabStatistics.Controls.Add(this.dtpEndTime);
            this.tabStatistics.Controls.Add(this.dtpStartTime);
            this.tabStatistics.Controls.Add(this.btnExportReportStatistics);
            this.tabStatistics.Controls.Add(this.btnStoreReportStatistics);
            this.tabStatistics.Controls.Add(this.dgvStatistics);
            this.tabStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistics.Size = new System.Drawing.Size(1366, 521);
            this.tabStatistics.TabIndex = 1;
            this.tabStatistics.Text = "放射医生阅片统计";
            this.tabStatistics.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "检查时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(732, 9);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(112, 21);
            this.dtpEndTime.TabIndex = 4;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(581, 9);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(112, 21);
            this.dtpStartTime.TabIndex = 3;
            // 
            // btnExportReportStatistics
            // 
            this.btnExportReportStatistics.Location = new System.Drawing.Point(220, 7);
            this.btnExportReportStatistics.Name = "btnExportReportStatistics";
            this.btnExportReportStatistics.Size = new System.Drawing.Size(185, 23);
            this.btnExportReportStatistics.TabIndex = 2;
            this.btnExportReportStatistics.Text = "导出报表";
            this.btnExportReportStatistics.UseVisualStyleBackColor = true;
            this.btnExportReportStatistics.Click += new System.EventHandler(this.btnExportReportStatistics_Click);
            // 
            // btnStoreReportStatistics
            // 
            this.btnStoreReportStatistics.Location = new System.Drawing.Point(18, 7);
            this.btnStoreReportStatistics.Name = "btnStoreReportStatistics";
            this.btnStoreReportStatistics.Size = new System.Drawing.Size(185, 23);
            this.btnStoreReportStatistics.TabIndex = 1;
            this.btnStoreReportStatistics.Text = "按照门店生成报表";
            this.btnStoreReportStatistics.UseVisualStyleBackColor = true;
            this.btnStoreReportStatistics.Click += new System.EventHandler(this.btnStoreReportStatistics_Click);
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreName,
            this.DoctorName,
            this.CTDiagnosis,
            this.CTAudit,
            this.CTCount,
            this.MRDiagnosis,
            this.MRAudit,
            this.MRCount,
            this.DRDiagnosis,
            this.DRAudit,
            this.DRCount});
            this.dgvStatistics.Location = new System.Drawing.Point(3, 44);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.ReadOnly = true;
            this.dgvStatistics.RowTemplate.Height = 23;
            this.dgvStatistics.Size = new System.Drawing.Size(1355, 473);
            this.dgvStatistics.TabIndex = 0;
            // 
            // StoreName
            // 
            this.StoreName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StoreName.HeaderText = "门店";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            this.StoreName.Width = 54;
            // 
            // DoctorName
            // 
            this.DoctorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DoctorName.HeaderText = "医生";
            this.DoctorName.Name = "DoctorName";
            this.DoctorName.ReadOnly = true;
            this.DoctorName.Width = 54;
            // 
            // CTDiagnosis
            // 
            this.CTDiagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CTDiagnosis.HeaderText = "CT诊断";
            this.CTDiagnosis.Name = "CTDiagnosis";
            this.CTDiagnosis.ReadOnly = true;
            this.CTDiagnosis.Width = 66;
            // 
            // CTAudit
            // 
            this.CTAudit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CTAudit.HeaderText = "CT终审";
            this.CTAudit.Name = "CTAudit";
            this.CTAudit.ReadOnly = true;
            this.CTAudit.Width = 66;
            // 
            // CTCount
            // 
            this.CTCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CTCount.HeaderText = "CT合计";
            this.CTCount.Name = "CTCount";
            this.CTCount.ReadOnly = true;
            this.CTCount.Width = 66;
            // 
            // MRDiagnosis
            // 
            this.MRDiagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MRDiagnosis.HeaderText = "MR诊断";
            this.MRDiagnosis.Name = "MRDiagnosis";
            this.MRDiagnosis.ReadOnly = true;
            this.MRDiagnosis.Width = 66;
            // 
            // MRAudit
            // 
            this.MRAudit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MRAudit.HeaderText = "MR终审";
            this.MRAudit.Name = "MRAudit";
            this.MRAudit.ReadOnly = true;
            this.MRAudit.Width = 66;
            // 
            // MRCount
            // 
            this.MRCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MRCount.HeaderText = "MR合计";
            this.MRCount.Name = "MRCount";
            this.MRCount.ReadOnly = true;
            this.MRCount.Width = 66;
            // 
            // DRDiagnosis
            // 
            this.DRDiagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DRDiagnosis.HeaderText = "DR诊断";
            this.DRDiagnosis.Name = "DRDiagnosis";
            this.DRDiagnosis.ReadOnly = true;
            this.DRDiagnosis.Width = 66;
            // 
            // DRAudit
            // 
            this.DRAudit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DRAudit.HeaderText = "DR终审";
            this.DRAudit.Name = "DRAudit";
            this.DRAudit.ReadOnly = true;
            this.DRAudit.Width = 66;
            // 
            // DRCount
            // 
            this.DRCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DRCount.HeaderText = "DR合计";
            this.DRCount.Name = "DRCount";
            this.DRCount.ReadOnly = true;
            this.DRCount.Width = 66;
            // 
            // tabDoctorPrice
            // 
            this.tabDoctorPrice.Controls.Add(this.btnSearchDoctorPrice);
            this.tabDoctorPrice.Controls.Add(this.progressBarDoctorPrice);
            this.tabDoctorPrice.Controls.Add(this.btnImportDoctorPrice);
            this.tabDoctorPrice.Controls.Add(this.label4);
            this.tabDoctorPrice.Controls.Add(this.btnBrownDoctorPrice);
            this.tabDoctorPrice.Controls.Add(this.txtDoctorPrice);
            this.tabDoctorPrice.Controls.Add(this.dgvRadiationDoctorPriceDetial);
            this.tabDoctorPrice.Location = new System.Drawing.Point(4, 22);
            this.tabDoctorPrice.Name = "tabDoctorPrice";
            this.tabDoctorPrice.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoctorPrice.Size = new System.Drawing.Size(1366, 521);
            this.tabDoctorPrice.TabIndex = 2;
            this.tabDoctorPrice.Text = "放射医生价格";
            this.tabDoctorPrice.UseVisualStyleBackColor = true;
            // 
            // btnSearchDoctorPrice
            // 
            this.btnSearchDoctorPrice.Location = new System.Drawing.Point(821, 11);
            this.btnSearchDoctorPrice.Name = "btnSearchDoctorPrice";
            this.btnSearchDoctorPrice.Size = new System.Drawing.Size(89, 23);
            this.btnSearchDoctorPrice.TabIndex = 12;
            this.btnSearchDoctorPrice.Text = "查询医生价格";
            this.btnSearchDoctorPrice.UseVisualStyleBackColor = true;
            this.btnSearchDoctorPrice.Click += new System.EventHandler(this.btnSearchDoctorPrice_Click);
            // 
            // progressBarDoctorPrice
            // 
            this.progressBarDoctorPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDoctorPrice.Location = new System.Drawing.Point(4, 48);
            this.progressBarDoctorPrice.Name = "progressBarDoctorPrice";
            this.progressBarDoctorPrice.Size = new System.Drawing.Size(1354, 23);
            this.progressBarDoctorPrice.TabIndex = 11;
            // 
            // btnImportDoctorPrice
            // 
            this.btnImportDoctorPrice.Location = new System.Drawing.Point(740, 11);
            this.btnImportDoctorPrice.Name = "btnImportDoctorPrice";
            this.btnImportDoctorPrice.Size = new System.Drawing.Size(75, 23);
            this.btnImportDoctorPrice.TabIndex = 10;
            this.btnImportDoctorPrice.Text = "导入数据";
            this.btnImportDoctorPrice.UseVisualStyleBackColor = true;
            this.btnImportDoctorPrice.Click += new System.EventHandler(this.btnImportDoctorPrice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "导入放射医生价格文件：";
            // 
            // btnBrownDoctorPrice
            // 
            this.btnBrownDoctorPrice.Location = new System.Drawing.Point(659, 11);
            this.btnBrownDoctorPrice.Name = "btnBrownDoctorPrice";
            this.btnBrownDoctorPrice.Size = new System.Drawing.Size(75, 23);
            this.btnBrownDoctorPrice.TabIndex = 8;
            this.btnBrownDoctorPrice.Text = "浏览";
            this.btnBrownDoctorPrice.UseVisualStyleBackColor = true;
            this.btnBrownDoctorPrice.Click += new System.EventHandler(this.btnDoctorPrice_Click);
            // 
            // txtDoctorPrice
            // 
            this.txtDoctorPrice.Location = new System.Drawing.Point(149, 11);
            this.txtDoctorPrice.Name = "txtDoctorPrice";
            this.txtDoctorPrice.Size = new System.Drawing.Size(504, 21);
            this.txtDoctorPrice.TabIndex = 7;
            // 
            // dgvRadiationDoctorPriceDetial
            // 
            this.dgvRadiationDoctorPriceDetial.AllowUserToDeleteRows = false;
            this.dgvRadiationDoctorPriceDetial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRadiationDoctorPriceDetial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvRadiationDoctorPriceDetial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRadiationDoctorPriceDetial.Location = new System.Drawing.Point(4, 71);
            this.dgvRadiationDoctorPriceDetial.MultiSelect = false;
            this.dgvRadiationDoctorPriceDetial.Name = "dgvRadiationDoctorPriceDetial";
            this.dgvRadiationDoctorPriceDetial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRadiationDoctorPriceDetial.RowTemplate.Height = 23;
            this.dgvRadiationDoctorPriceDetial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRadiationDoctorPriceDetial.Size = new System.Drawing.Size(1354, 447);
            this.dgvRadiationDoctorPriceDetial.TabIndex = 6;
            this.dgvRadiationDoctorPriceDetial.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRadiationDoctorPriceDetial_CellValueChanged);
            // 
            // tabDoctorStatistics
            // 
            this.tabDoctorStatistics.Controls.Add(this.groupBox2);
            this.tabDoctorStatistics.Controls.Add(this.groupBox1);
            this.tabDoctorStatistics.Controls.Add(this.label5);
            this.tabDoctorStatistics.Controls.Add(this.label6);
            this.tabDoctorStatistics.Controls.Add(this.dtpRadiationDoctorEndTime);
            this.tabDoctorStatistics.Controls.Add(this.dtpRadiationDoctorStartTime);
            this.tabDoctorStatistics.Controls.Add(this.btnExportRadiationDoctorReport);
            this.tabDoctorStatistics.Controls.Add(this.btnRadiationDoctorReport);
            this.tabDoctorStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabDoctorStatistics.Name = "tabDoctorStatistics";
            this.tabDoctorStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoctorStatistics.Size = new System.Drawing.Size(1366, 521);
            this.tabDoctorStatistics.TabIndex = 3;
            this.tabDoctorStatistics.Text = "放射医生费用统计";
            this.tabDoctorStatistics.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvRadiationDoctorPrice);
            this.groupBox2.Location = new System.Drawing.Point(884, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 480);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "医生费用信息";
            // 
            // dgvRadiationDoctorPrice
            // 
            this.dgvRadiationDoctorPrice.AllowUserToAddRows = false;
            this.dgvRadiationDoctorPrice.AllowUserToDeleteRows = false;
            this.dgvRadiationDoctorPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRadiationDoctorPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRadiationDoctorPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DN,
            this.CTD,
            this.MRD,
            this.CTA,
            this.MRA,
            this.TotalPrice});
            this.dgvRadiationDoctorPrice.Location = new System.Drawing.Point(6, 20);
            this.dgvRadiationDoctorPrice.Name = "dgvRadiationDoctorPrice";
            this.dgvRadiationDoctorPrice.ReadOnly = true;
            this.dgvRadiationDoctorPrice.RowTemplate.Height = 23;
            this.dgvRadiationDoctorPrice.Size = new System.Drawing.Size(733, 460);
            this.dgvRadiationDoctorPrice.TabIndex = 0;
            // 
            // DN
            // 
            this.DN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DN.HeaderText = "医生";
            this.DN.Name = "DN";
            this.DN.ReadOnly = true;
            this.DN.Width = 54;
            // 
            // CTD
            // 
            this.CTD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CTD.HeaderText = "CT诊断数";
            this.CTD.Name = "CTD";
            this.CTD.ReadOnly = true;
            this.CTD.Width = 78;
            // 
            // MRD
            // 
            this.MRD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MRD.HeaderText = "MR诊断数";
            this.MRD.Name = "MRD";
            this.MRD.ReadOnly = true;
            this.MRD.Width = 78;
            // 
            // CTA
            // 
            this.CTA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CTA.HeaderText = "CT核片数";
            this.CTA.Name = "CTA";
            this.CTA.ReadOnly = true;
            this.CTA.Width = 78;
            // 
            // MRA
            // 
            this.MRA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MRA.HeaderText = "MR核片数";
            this.MRA.Name = "MRA";
            this.MRA.ReadOnly = true;
            this.MRA.Width = 78;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalPrice.HeaderText = "应付费用";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 78;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvRadiationStoreDoctorPrice);
            this.groupBox1.Location = new System.Drawing.Point(18, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 480);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "门店医生费用信息";
            // 
            // dgvRadiationStoreDoctorPrice
            // 
            this.dgvRadiationStoreDoctorPrice.AllowUserToAddRows = false;
            this.dgvRadiationStoreDoctorPrice.AllowUserToDeleteRows = false;
            this.dgvRadiationStoreDoctorPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRadiationStoreDoctorPrice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvRadiationStoreDoctorPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRadiationStoreDoctorPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.DoctorPrice,
            this.Note});
            this.dgvRadiationStoreDoctorPrice.Location = new System.Drawing.Point(6, 20);
            this.dgvRadiationStoreDoctorPrice.Name = "dgvRadiationStoreDoctorPrice";
            this.dgvRadiationStoreDoctorPrice.ReadOnly = true;
            this.dgvRadiationStoreDoctorPrice.RowTemplate.Height = 23;
            this.dgvRadiationStoreDoctorPrice.Size = new System.Drawing.Size(854, 463);
            this.dgvRadiationStoreDoctorPrice.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "门店";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "医生";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "CT诊断";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 66;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "CT终审";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 66;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "MR诊断";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 66;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "MR终审";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 66;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "DR诊断";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 66;
            // 
            // DoctorPrice
            // 
            this.DoctorPrice.HeaderText = "费用";
            this.DoctorPrice.Name = "DoctorPrice";
            this.DoctorPrice.ReadOnly = true;
            // 
            // Note
            // 
            this.Note.HeaderText = "备注";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(709, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "检查时间：";
            // 
            // dtpRadiationDoctorEndTime
            // 
            this.dtpRadiationDoctorEndTime.Location = new System.Drawing.Point(732, 8);
            this.dtpRadiationDoctorEndTime.Name = "dtpRadiationDoctorEndTime";
            this.dtpRadiationDoctorEndTime.Size = new System.Drawing.Size(112, 21);
            this.dtpRadiationDoctorEndTime.TabIndex = 11;
            // 
            // dtpRadiationDoctorStartTime
            // 
            this.dtpRadiationDoctorStartTime.Location = new System.Drawing.Point(581, 8);
            this.dtpRadiationDoctorStartTime.Name = "dtpRadiationDoctorStartTime";
            this.dtpRadiationDoctorStartTime.Size = new System.Drawing.Size(112, 21);
            this.dtpRadiationDoctorStartTime.TabIndex = 10;
            // 
            // btnExportRadiationDoctorReport
            // 
            this.btnExportRadiationDoctorReport.Location = new System.Drawing.Point(220, 6);
            this.btnExportRadiationDoctorReport.Name = "btnExportRadiationDoctorReport";
            this.btnExportRadiationDoctorReport.Size = new System.Drawing.Size(185, 23);
            this.btnExportRadiationDoctorReport.TabIndex = 9;
            this.btnExportRadiationDoctorReport.Text = "导出报表";
            this.btnExportRadiationDoctorReport.UseVisualStyleBackColor = true;
            this.btnExportRadiationDoctorReport.Click += new System.EventHandler(this.btnExportRadiationDoctorReport_Click);
            // 
            // btnRadiationDoctorReport
            // 
            this.btnRadiationDoctorReport.Location = new System.Drawing.Point(18, 6);
            this.btnRadiationDoctorReport.Name = "btnRadiationDoctorReport";
            this.btnRadiationDoctorReport.Size = new System.Drawing.Size(185, 23);
            this.btnRadiationDoctorReport.TabIndex = 8;
            this.btnRadiationDoctorReport.Text = "生成报表";
            this.btnRadiationDoctorReport.UseVisualStyleBackColor = true;
            this.btnRadiationDoctorReport.Click += new System.EventHandler(this.btnRadiationDoctorReport_Click);
            // 
            // processTimer
            // 
            this.processTimer.Tick += new System.EventHandler(this.processTimer_Tick);
            // 
            // frmImageStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 552);
            this.Controls.Add(this.tabImage);
            this.Name = "frmImageStatistics";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "大象医疗科技有限公司";
            this.Load += new System.EventHandler(this.frmImageStatistics_Load);
            this.tabImage.ResumeLayout(false);
            this.tabOrgionFile.ResumeLayout(false);
            this.tabOrgionFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgionView)).EndInit();
            this.tabStatistics.ResumeLayout(false);
            this.tabStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.tabDoctorPrice.ResumeLayout(false);
            this.tabDoctorPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadiationDoctorPriceDetial)).EndInit();
            this.tabDoctorStatistics.ResumeLayout(false);
            this.tabDoctorStatistics.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadiationDoctorPrice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadiationStoreDoctorPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabImage;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowns;
        private System.Windows.Forms.TextBox txtImageFilePath;
        protected System.Windows.Forms.TabPage tabOrgionFile;
        protected System.Windows.Forms.DataGridView dgvOrgionView;
        private System.Windows.Forms.Button btnImprot;
        private System.Windows.Forms.ProgressBar processBarImport;
        private System.Windows.Forms.Timer processTimer;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.Button btnStoreReportStatistics;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportReportStatistics;
        private System.Windows.Forms.TabPage tabDoctorPrice;
        private System.Windows.Forms.ProgressBar progressBarDoctorPrice;
        private System.Windows.Forms.Button btnImportDoctorPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrownDoctorPrice;
        private System.Windows.Forms.TextBox txtDoctorPrice;
        protected System.Windows.Forms.DataGridView dgvRadiationDoctorPriceDetial;
        private System.Windows.Forms.Timer processDoctorPriceTimer;
        private System.Windows.Forms.TabPage tabDoctorStatistics;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpRadiationDoctorEndTime;
        private System.Windows.Forms.DateTimePicker dtpRadiationDoctorStartTime;
        private System.Windows.Forms.Button btnExportRadiationDoctorReport;
        private System.Windows.Forms.Button btnRadiationDoctorReport;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSearchDoctorPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRadiationStoreDoctorPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridView dgvRadiationDoctorPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.Button btnDeleteData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDeleteEndTime;
        private System.Windows.Forms.DateTimePicker dtpDeleteStartTime;
    }
}

