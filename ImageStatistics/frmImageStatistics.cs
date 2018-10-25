using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageStatisticsBLL;
using ImageStatisticsIBLL;
using ImageStatisticsModel;
using NLog;

namespace ImageStatistics
{
    public partial class frmImageStatistics : Form
    {
        private IImportFileService _importFileService = new ImportFileService();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public frmImageStatistics()
        {
            InitializeComponent();
        }

        private void btnBrowns_Click(object sender, EventArgs e)
        {
            //选择文件夹
            using (FolderBrowserDialog folderOpen = new FolderBrowserDialog())
            {
                if (folderOpen.ShowDialog() == DialogResult.OK)
                {
                    txtImageFilePath.Text = folderOpen.SelectedPath;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImageFilePath.Text))
            {
                MessageBox.Show("请选择要导入的文件夹!");

                return;
            }

            if (!Directory.Exists(txtImageFilePath.Text))
            {
                MessageBox.Show("不存在当前文件目录!");

                return;
            }

            processBarImport.Value = 0;
            processTimer.Enabled = true;

            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ImportFile);

            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(txtImageFilePath.Text);
            btnBrowns.Enabled = false;
            btnImprot.Enabled = false;
        }

        private void ImportFile(object parameter)
        {
            string fileFold = parameter.ToString();
            if (!Directory.Exists(fileFold))
            {
                return;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(fileFold);

            bool isExistSuccess = false;

            foreach (var item in directoryInfo.GetFiles())
            {
                string fileFullName = item.FullName;

                UpdateLableHandler updateFileHandler = new UpdateLableHandler(UpdateFileName);
                lblFileName.Invoke(updateFileHandler, $"正在读取文件：" + fileFullName);

                DataTable table = _importFileService.GetDataTableFromExcelFile(fileFullName, string.Empty);
                if (table == null)
                {
                    MessageBox.Show("读取文件失败，文件路径：" + fileFullName);
                    lblFileName.Invoke(updateFileHandler, $"读取文件失败，文件路径：" + fileFullName);
                    continue;
                }

                isExistSuccess = true;

                UpdateDgvHandler updateDgvHandler = new UpdateDgvHandler(UpdateDgv);
                dgvOrgionView.Invoke(updateDgvHandler, table);

                lblFileName.Invoke(updateFileHandler, $"正在导入文件到数据库：" + fileFullName);

                InsertOrgionDataIntoDB(table, item.Name);

                lblFileName.Invoke(updateFileHandler, $"导入文件到数据库完成：" + fileFullName);
            }

            UpdateControlHandler updateControlHandler = new UpdateControlHandler(UpdateControl);
            processBarImport.Invoke(updateControlHandler);

            if (!isExistSuccess)
            {
                UpdateDgvHandler updateDgvHandler = new UpdateDgvHandler(UpdateDgv);
                dgvOrgionView.Invoke(updateDgvHandler, new DataTable());
                MessageBox.Show("数据导入完成,但没读取到任何数据!");
                return;
            }

            MessageBox.Show("数据导入完成!");
        }


        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            DateTime startTime = dtpDeleteStartTime.Value.Date;
            DateTime endTime = dtpDeleteEndTime.Value.Date.AddDays(1);
            DialogResult dialogResult = MessageBox.Show("您确定要删除从 " + startTime.ToLongDateString() + "到" + endTime.ToLongDateString() + "之间的数据么？删除后不可恢复!", "警告", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    int rows = _importFileService.DeleteStoreDoctorDetail(startTime, endTime);

                    MessageBox.Show("删除的行数：" + rows);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除数据出错，错误信息!" + ex.Message);
                }
            }
        }

        private void InsertOrgionDataIntoDB(object parameter, string fileName)
        {
            try
            {
                DataTable dataTable = parameter as DataTable;
                if (dataTable != null)
                {
                    dataTable.Columns.Add(new DataColumn("Id", Type.GetType("System.Guid")));
                    dataTable.Columns.Add(new DataColumn("FileName", Type.GetType("System.String")));

                    foreach (DataColumn item in dataTable.Columns)
                    {
                        bool isFinded = false;
                        string columnName = item.ColumnName;
                        foreach (PropertyInfo property in typeof(StoreDoctorDetial).GetProperties())
                        {
                            if (isFinded) { continue; }
                            Object[] obs = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                            foreach (DescriptionAttribute descriptionAttribute in obs)
                            {
                                if (descriptionAttribute.Description.Equals(columnName))
                                {
                                    item.ColumnName = property.Name;
                                    isFinded = true;
                                }
                            }
                        }
                    }
                    dataTable.Columns["Id"].SetOrdinal(0);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["Id"] = Guid.NewGuid().ToString();
                        row["FileName"] = fileName;
                    }

                    _importFileService.InsertOrgionDataIntoDatabase(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入到数据库出错!" + ex.Message);
                Logger.Info($"插入到数据库出错!" + ex.Message);
            }
        }

        private delegate void UpdateDgvHandler(DataTable dataTable);
        private delegate void UpdateLableHandler(string fileFullName);
        private delegate void UpdateControlHandler();

        private void UpdateFileName(string message)
        {
            lblFileName.Text = message;
        }

        private void UpdateControl()
        {
            btnBrowns.Enabled = true;
            btnImprot.Enabled = true;
            processTimer.Enabled = false;
            processBarImport.Value = processBarImport.Maximum;
        }

        private void UpdateDgv(DataTable dataTable)
        {
            if (dgvOrgionView.DataSource == null)
            {
                dgvOrgionView.DataSource = dataTable;
                dgvOrgionView.Refresh();
            }
        }

        private void processTimer_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (processBarImport.Value < processBarImport.Maximum)
            {
                processBarImport.Value += 1;
            }
            else
            {
                processBarImport.Value = 0;
            }
        }

        private void btnStoreReportStatistics_Click(object sender, EventArgs e)
        {
            DateTime startTime = dtpStartTime.Value.Date;
            DateTime endTime = dtpEndTime.Value.Date.AddDays(1);

            Dictionary<string, List<DoctorStatistics>> dictionary = _importFileService.GetStoreDoctorDetialDic(startTime, endTime);

            List<StoreStatistics> storeStatisticsList = new List<StoreStatistics>();

            dgvStatistics.Rows.Clear();

            foreach (var item in dictionary)
            {
                string storeName = item.Key;

                List<DoctorStatistics> doctorStatisticsList = dictionary[item.Key];
                foreach (var doctorStatistics in doctorStatisticsList)
                {
                    StoreStatistics storeStatistics = new StoreStatistics();

                    storeStatistics.StoreName = storeName;
                    storeStatistics.DoctorName = doctorStatistics.DoctorName;

                    storeStatistics.CTAuditCount = doctorStatistics.CTAuditCount;
                    storeStatistics.CTDiagnosisCount = doctorStatistics.CTDiagnosisCount;
                    storeStatistics.CTCount = doctorStatistics.CTCount;

                    storeStatistics.DRAuditCount = doctorStatistics.DRAuditCount;
                    storeStatistics.DRDiagnosisCount = doctorStatistics.DRDiagnosisCount;
                    storeStatistics.DRCount = doctorStatistics.DRCount;

                    storeStatistics.MRAuditCount = doctorStatistics.MRAuditCount;
                    storeStatistics.MRDiagnosisCount = doctorStatistics.MRDiagnosisCount;
                    storeStatistics.MRCount = doctorStatistics.MRCount;

                    storeStatisticsList.Add(storeStatistics);

                    dgvStatistics.Rows.Add(storeStatistics.StoreName, storeStatistics.DoctorName,
                        storeStatistics.CTDiagnosisCount, storeStatistics.CTAuditCount, storeStatistics.CTCount,
                        storeStatistics.MRDiagnosisCount, storeStatistics.MRAuditCount, storeStatistics.MRCount,
                        storeStatistics.DRDiagnosisCount, storeStatistics.DRAuditCount, storeStatistics.DRCount);
                }
            }

            MessageBox.Show("按照门店生成报表成功!");
        }

        private void btnExportReportStatistics_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "(*.xls;*xlsx)|*.xls;*xlsx";
                string fileName = $"医生工作量{DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")}";
                dialog.FileName = fileName;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileFullName = dialog.FileName;

                    DataTable dataTable = new DataTable();
                    dataTable.TableName = fileName;
                    dataTable.Columns.Add("门店");
                    dataTable.Columns.Add("医生");
                    dataTable.Columns.Add("CT诊断");
                    dataTable.Columns.Add("CT终审");
                    dataTable.Columns.Add("CT合计");
                    dataTable.Columns.Add("MR诊断");
                    dataTable.Columns.Add("MR终审");
                    dataTable.Columns.Add("MR合计");
                    dataTable.Columns.Add("DR诊断");
                    dataTable.Columns.Add("DR终审");
                    dataTable.Columns.Add("DR合计");

                    for (int rowIndex = 0; rowIndex < dgvStatistics.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow row = dgvStatistics.Rows[rowIndex];

                        object[] dataRow = new object[row.Cells.Count];
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dataRow[i] = row.Cells[i].Value.ToString();
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    DataTable[] dataTableArray = new DataTable[1];
                    dataTableArray[0] = dataTable;
                    if (_importFileService.Export(dataTableArray, fileFullName))
                    {
                        Logger.Info($"生成统计报表成功");
                        MessageBox.Show("生成统计报表成功！");
                    }
                    else
                    {
                        Logger.Info($"生成统计报表失败");
                        MessageBox.Show("生成统计报表失败！");
                    }
                }
            }
        }

        #region 医生价格导入、显示

        private void btnDoctorPrice_Click(object sender, EventArgs e)
        {
            //选择文件
            using (OpenFileDialog dlgOpen = new OpenFileDialog())
            {
                dlgOpen.Filter = "Excel Files (*.xls;*xlsx)|*.xls;*xlsx";
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    txtDoctorPrice.Text = dlgOpen.FileName;
                }
            }
        }

        private void btnImportDoctorPrice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDoctorPrice.Text))
            {
                MessageBox.Show("请选择要导入的医生价格文件!");

                return;
            }

            progressBarDoctorPrice.Value = 0;
            processDoctorPriceTimer.Enabled = true;

            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ImportDoctorPriceFile);

            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(txtDoctorPrice.Text);
            btnBrownDoctorPrice.Enabled = false;
            btnImportDoctorPrice.Enabled = false;
        }

        private void ImportDoctorPriceFile(object parameter)
        {
            string doctorPriceFileName = parameter.ToString();
            if (!File.Exists(doctorPriceFileName))
            {
                Console.WriteLine("不存在医生价格文件，文件名：" + doctorPriceFileName);
                Logger.Info($"不存在医生价格文件，文件名：" + doctorPriceFileName);
                return;
            }


            string fileFullName = doctorPriceFileName;
            DataTable table = _importFileService.GetDataTableFromExcelFile(fileFullName, "医生价格");
            if (table == null)
            {
                MessageBox.Show("读取文件失败，文件路径：" + fileFullName);
                Console.WriteLine("读取医生价格文件失败，文件名：" + doctorPriceFileName);
                Logger.Info($"读取医生价格文件失败，文件名：" + doctorPriceFileName);
                return;
            }

            InsertDoctorPriceDataIntoDB(table);

            UpdateDgvHandler updateDgvHandler = new UpdateDgvHandler(UpdateDoctorPriceDgv);
            dgvOrgionView.Invoke(updateDgvHandler, table);

            Logger.Info($"医生价格数据导入成功!");
            MessageBox.Show("医生价格数据导入成功!");
        }

        private void InsertDoctorPriceDataIntoDB(object parameter)
        {
            try
            {
                DataTable dataTable = parameter as DataTable;
                if (dataTable != null)
                {
                    List<DoctorPriceDetial> list = _importFileService.GetDoctorPriceDetialList(dataTable);
                    _importFileService.InsertDoctorPriceDataIntoDatabase(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("添加医生价格输入到数据库出错!" + ex.Message);
                Logger.Info($"添加医生价格输入到数据库出错!" + ex.Message);
            }
        }

        private void UpdateDoctorPriceDgv(DataTable dataTable)
        {
            FillDgvRadiationDoctorPriceDetial();
            //this.doctorPriceDetialsTableAdapter.Fill(this.elephantImageStatisticsDataSet.DoctorPriceDetials);
            btnBrownDoctorPrice.Enabled = true;
            btnImportDoctorPrice.Enabled = true;
            processDoctorPriceTimer.Enabled = false;
            progressBarDoctorPrice.Value = progressBarDoctorPrice.Maximum;
        }

        private void btnSearchDoctorPrice_Click(object sender, EventArgs e)
        {
            FillDgvRadiationDoctorPriceDetial();

            //this.doctorPriceDetialsTableAdapter.Fill(this.elephantImageStatisticsDataSet.DoctorPriceDetials);
        }

        private void FillDgvRadiationDoctorPriceDetial()
        {
            var result = _importFileService.GetDoctorPriceDetialList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("标识");
            dataTable.Columns.Add("序号");
            dataTable.Columns.Add("医生");
            dataTable.Columns.Add("CT诊断（元/张）");
            dataTable.Columns.Add("MRI诊断（元/张）");
            dataTable.Columns.Add("DR诊断（元/张）");
            dataTable.Columns.Add("CT核片（元/张）");
            dataTable.Columns.Add("MRI核片（元/张）");
            dataTable.Columns.Add("备注");

            dataTable.Columns[0].ReadOnly = true;

            for (int i = 0; i < result.Count; i++)
            {
                dataTable.Rows.Add(result[i].Id, result[i].No, result[i].DoctorName, result[i].CTDiagnosisPrice, result[i].MRDiagnosisPrice, result[i].DRDiagnosisPrice, result[i].CTAuditPrice, result[i].MRAuditPrice, result[i].Note);
            }
            dgvRadiationDoctorPriceDetial.DataSource = dataTable;
        }

        #endregion


        #region 价格统计结果Tab

        private void btnRadiationDoctorReport_Click(object sender, EventArgs e)
        {
            DateTime startTime = dtpRadiationDoctorStartTime.Value.Date;
            DateTime endTime = dtpRadiationDoctorEndTime.Value.Date.AddDays(1);

            Dictionary<string, List<DoctorStatistics>> dictionary = _importFileService.GetStoreDoctorDetialDic(startTime, endTime);

            List<DoctorStatistics> doctorStatisticsList = new List<DoctorStatistics>();

            dgvRadiationStoreDoctorPrice.Rows.Clear();
            dgvRadiationDoctorPrice.Rows.Clear();

            foreach (var item in dictionary)
            {
                string storeName = item.Key;

                List<DoctorStatistics> storeDoctorStatisticsList = dictionary[item.Key];
                foreach (var doctorStatistics in storeDoctorStatisticsList)
                {
                    StoreStatistics storeStatistics = new StoreStatistics();

                    storeStatistics.StoreName = storeName;
                    storeStatistics.DoctorName = doctorStatistics.DoctorName;

                    storeStatistics.CTAuditCount = doctorStatistics.CTAuditCount;
                    storeStatistics.CTDiagnosisCount = doctorStatistics.CTDiagnosisCount;
                    storeStatistics.CTCount = doctorStatistics.CTCount;

                    storeStatistics.DRAuditCount = doctorStatistics.DRAuditCount;
                    storeStatistics.DRDiagnosisCount = doctorStatistics.DRDiagnosisCount;
                    storeStatistics.DRCount = doctorStatistics.DRCount;

                    storeStatistics.MRAuditCount = doctorStatistics.MRAuditCount;
                    storeStatistics.MRDiagnosisCount = doctorStatistics.MRDiagnosisCount;
                    storeStatistics.MRCount = doctorStatistics.MRCount;

                    string priceStr = "没有找到此医生对应的放射价格.";

                    DoctorPriceDetial doctorPriceDetial = _importFileService.GetDoctorPriceDetial(storeStatistics.DoctorName);
                    if (doctorPriceDetial != null)
                    {
                        string CTDiagnosisPriceStr = doctorPriceDetial.CTDiagnosisPrice;
                        if (string.IsNullOrEmpty(CTDiagnosisPriceStr)) { CTDiagnosisPriceStr = "0"; }

                        string CTAuditPriceStr = doctorPriceDetial.CTAuditPrice;
                        if (string.IsNullOrEmpty(CTAuditPriceStr)) { CTAuditPriceStr = "0"; }

                        string MRDiagnosisPriceStr = doctorPriceDetial.MRDiagnosisPrice;
                        if (string.IsNullOrEmpty(MRDiagnosisPriceStr)) { MRDiagnosisPriceStr = "0"; }

                        string MRAuditPriceStr = doctorPriceDetial.MRAuditPrice;
                        if (string.IsNullOrEmpty(MRAuditPriceStr)) { MRAuditPriceStr = "0"; }

                        string DRDiagnosisPriceStr = doctorPriceDetial.DRDiagnosisPrice;
                        if (string.IsNullOrEmpty(DRDiagnosisPriceStr)) { DRDiagnosisPriceStr = "0"; }


                        decimal CTDiagnosisPrice = storeStatistics.CTDiagnosisCount * Convert.ToDecimal(CTDiagnosisPriceStr);
                        decimal CTAuditPrice = storeStatistics.CTAuditCount * Convert.ToDecimal(CTAuditPriceStr);

                        decimal MRDiagnosisPrice = storeStatistics.MRDiagnosisCount * Convert.ToDecimal(MRDiagnosisPriceStr);
                        decimal MRAuditPrice = storeStatistics.MRAuditCount * Convert.ToDecimal(MRAuditPriceStr);

                        decimal DRDiagnosisPrice = storeStatistics.DRDiagnosisCount * Convert.ToDecimal(DRDiagnosisPriceStr);
                        //decimal DRAuditPrice = storeStatistics.DRAuditCount * Convert.ToDecimal(doctorPriceDetial.DR); //TODO::这个暂时没有

                        doctorStatistics.Price = CTDiagnosisPrice + CTAuditPrice + MRDiagnosisPrice + MRAuditPrice + DRDiagnosisPrice;
                        storeStatistics.Price = doctorStatistics.Price;

                        doctorStatistics.IsContainPrice = true;
                        storeStatistics.IsContainPrice = true;

                        priceStr = storeStatistics.Price.ToString();
                    }

                    var findDoctorStatistics = doctorStatisticsList.Find(d => d.DoctorName.Equals(doctorStatistics.DoctorName));
                    if (findDoctorStatistics != null) //找到了此医生
                    {
                        findDoctorStatistics.CTDiagnosisCount += doctorStatistics.CTDiagnosisCount;
                        findDoctorStatistics.CTAuditCount += doctorStatistics.CTAuditCount;
                        findDoctorStatistics.DRDiagnosisCount += doctorStatistics.DRDiagnosisCount;
                        findDoctorStatistics.DRAuditCount += doctorStatistics.DRAuditCount;
                        findDoctorStatistics.MRDiagnosisCount += doctorStatistics.MRDiagnosisCount;
                        findDoctorStatistics.MRAuditCount += doctorStatistics.MRAuditCount;

                        findDoctorStatistics.IsContainPrice = doctorStatistics.IsContainPrice;
                        findDoctorStatistics.Price += doctorStatistics.Price;
                    }
                    else //没有找到此医生
                    {
                        DoctorStatistics currentDoctorStatistics = new DoctorStatistics();

                        currentDoctorStatistics.DoctorName = doctorStatistics.DoctorName;
                        currentDoctorStatistics.CTDiagnosisCount = doctorStatistics.CTDiagnosisCount;
                        currentDoctorStatistics.CTAuditCount = doctorStatistics.CTAuditCount;
                        currentDoctorStatistics.DRDiagnosisCount = doctorStatistics.DRDiagnosisCount;
                        currentDoctorStatistics.DRAuditCount = doctorStatistics.DRAuditCount;
                        currentDoctorStatistics.MRDiagnosisCount = doctorStatistics.MRDiagnosisCount;
                        currentDoctorStatistics.MRAuditCount = doctorStatistics.MRAuditCount;

                        currentDoctorStatistics.IsContainPrice = doctorStatistics.IsContainPrice;
                        currentDoctorStatistics.Price = doctorStatistics.Price;

                        doctorStatisticsList.Add(currentDoctorStatistics);
                    }

                    dgvRadiationStoreDoctorPrice.Rows.Add(storeStatistics.StoreName, storeStatistics.DoctorName,
                        storeStatistics.CTDiagnosisCount, storeStatistics.CTAuditCount,
                        storeStatistics.MRDiagnosisCount, storeStatistics.MRAuditCount,
                        storeStatistics.DRDiagnosisCount, priceStr, string.Empty);
                }
            }

            foreach (var item in doctorStatisticsList)
            {
                dgvRadiationDoctorPrice.Rows.Add(item.DoctorName, item.CTDiagnosisCount, item.MRDiagnosisCount, item.CTAuditCount, item.MRAuditCount, item.IsContainPrice ? item.Price.ToString() : "没有找到此医生对应的放射价格.");
            }

            MessageBox.Show("生成报表成功！");
        }

        private void btnExportRadiationDoctorReport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "(*.xls;*xlsx)|*.xls;*xlsx";
                string fileName = $"医生工作费用{DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")}";
                dialog.FileName = fileName;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileFullName = dialog.FileName;

                    DataTable storeDoctorPriceDetialTable = new DataTable();
                    storeDoctorPriceDetialTable.TableName = $"医生费用详情";
                    storeDoctorPriceDetialTable.Columns.Add("门店");
                    storeDoctorPriceDetialTable.Columns.Add("医生");
                    storeDoctorPriceDetialTable.Columns.Add("CT诊断");
                    storeDoctorPriceDetialTable.Columns.Add("CT终审");
                    storeDoctorPriceDetialTable.Columns.Add("MR诊断");
                    storeDoctorPriceDetialTable.Columns.Add("MR终审");
                    storeDoctorPriceDetialTable.Columns.Add("DR诊断");
                    storeDoctorPriceDetialTable.Columns.Add("费用");
                    storeDoctorPriceDetialTable.Columns.Add("备注");

                    foreach (DataGridViewRow row in dgvRadiationStoreDoctorPrice.Rows)
                    {
                        object[] dataRow = new object[row.Cells.Count];
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dataRow[i] = row.Cells[i].Value.ToString();
                        }
                        storeDoctorPriceDetialTable.Rows.Add(dataRow);
                    }

                    DataTable doctorPriceTable = new DataTable();
                    doctorPriceTable.TableName = $"医生总计费用";
                    doctorPriceTable.Columns.Add("医生");
                    doctorPriceTable.Columns.Add("CT诊断数");
                    doctorPriceTable.Columns.Add("MR诊断数");
                    doctorPriceTable.Columns.Add("CT核片数");
                    doctorPriceTable.Columns.Add("MR核片数");
                    doctorPriceTable.Columns.Add("应付费用");

                    foreach (DataGridViewRow row in dgvRadiationDoctorPrice.Rows)
                    {
                        object[] dataRow = new object[row.Cells.Count];
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dataRow[i] = row.Cells[i].Value.ToString();
                        }
                        doctorPriceTable.Rows.Add(dataRow);
                    }

                    DataTable[] dataTableArray = new DataTable[2];

                    dataTableArray[0] = storeDoctorPriceDetialTable;
                    dataTableArray[1] = doctorPriceTable;

                    if (_importFileService.Export(dataTableArray, fileFullName))
                    {
                        Logger.Info($"生成医生费用统计报表成功！");
                        MessageBox.Show("生成医生费用统计报表成功！");
                    }
                    else
                    {
                        Logger.Info($"生成医生费用统计报表失败！");
                        MessageBox.Show("生成医生费用统计报表失败！");
                    }
                }
            }
        }

        #endregion

        private void frmImageStatistics_Load(object sender, EventArgs e)
        {
            FillDgvRadiationDoctorPriceDetial();
        }

        private void dgvRadiationDoctorPriceDetial_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;
                if (dataGridView == null) { return; }

                int rowIndex = e.RowIndex;

                DataGridViewRow dataGridViewRow = dataGridView.Rows[rowIndex];

                DoctorPriceDetial doctorPriceDetial = new DoctorPriceDetial();

                Guid guid;
                bool isSuccess = Guid.TryParse(dataGridViewRow.Cells[0].Value.ToString(), out guid);

                doctorPriceDetial.Id = guid;
                doctorPriceDetial.No = int.Parse(dataGridViewRow.Cells[1].Value.ToString());
                doctorPriceDetial.DoctorName = dataGridViewRow.Cells[2].Value.ToString();
                doctorPriceDetial.CTDiagnosisPrice = dataGridViewRow.Cells[3].Value.ToString();
                doctorPriceDetial.MRDiagnosisPrice = dataGridViewRow.Cells[4].Value.ToString();
                doctorPriceDetial.DRDiagnosisPrice = dataGridViewRow.Cells[5].Value.ToString();
                doctorPriceDetial.CTAuditPrice = dataGridViewRow.Cells[6].Value.ToString();
                doctorPriceDetial.MRAuditPrice = dataGridViewRow.Cells[7].Value.ToString();
                doctorPriceDetial.Note = dataGridViewRow.Cells[8].Value.ToString();

                if (_importFileService.FindDoctorPriceById(doctorPriceDetial.Id) != null)
                {
                    _importFileService.UpdteDoctorPriceDetial(doctorPriceDetial);
                }

                if (_importFileService.FindDoctorPriceById(doctorPriceDetial.Id) == null)
                {
                    _importFileService.CreateDoctorPriceDetial(doctorPriceDetial);
                }

                var findResult = _importFileService.FindDoctorPriceById(doctorPriceDetial.Id);
                if (findResult != null)
                {
                    if (dataGridViewRow.Cells[0].Value == null)
                    {
                        dataGridViewRow.Cells[0].Value = findResult.Id;
                    }
                    if (dataGridViewRow.Cells[0].Value.ToString() != findResult.Id.ToString())
                    {
                        dataGridViewRow.Cells[0].Value = findResult.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Info($"触发函数dgvRadiationDoctorPriceDetial_CellValueChanged失败！" + ex.Message);
            }
        }
    }
}
