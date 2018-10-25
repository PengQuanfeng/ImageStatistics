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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace ImageStatisticsTool
{
    public partial class frmProcessExcel : Form
    {
        private Excel.Application excelApplication = null;
        private Excel.Workbooks excelWorkbooks;
        private Excel.Workbook excelWorkbook;
        private string saveFilePath = string.Empty;
        private string openFilePath = string.Empty;

        public frmProcessExcel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭Excel程序
        /// </summary>
        private void CloseExcelApplication()
        {
            try
            {
                excelWorkbook = null;
                excelWorkbooks = null;
                if (excelApplication != null)
                {
                    excelApplication.Workbooks.Close();
                    excelApplication.Quit();
                    excelApplication = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void SaveCopyAs(string xlsfile, string saveAsFile)
        {
            if (excelApplication != null) CloseExcelApplication();
            if (string.IsNullOrEmpty(xlsfile)) throw new Exception("请选择一个文件！");

            if (!File.Exists(xlsfile))
                throw new Exception(xlsfile + "文件不存在！");
            else
            {
                try
                {
                    //点击引用到的第三方组件然后属性中将Embed Interop Types置为False, ActiveSheet.UsedRange.Rows.Count
                    excelApplication = new Excel.ApplicationClass();
                    excelWorkbooks = excelApplication.Workbooks;
                    excelWorkbook = excelWorkbooks.Open(xlsfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Excel.Workbook;
                    //excelWorksheet = excelWorkbook.Worksheets[activeSheetIndex] as Excel.Worksheet;
                    excelApplication.Visible = false;
                    _Application application = excelApplication as _Application;

                    application.ActiveWorkbook.SaveAs(saveAsFile, XlFileFormat.xlExcel9795, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 0, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    application.Quit();

                }
                catch (Exception ex)
                {
                    CloseExcelApplication();
                    throw new Exception(string.Format("（1）程序中没有安装Excel程序。（2）或没有安装Excel所需要支持的.NetFramework\n详细信息：{0}", ex.Message));
                }
            }

        }

        private delegate void UpdateDgvHandler();

        private void ImportFile(object parameter)
        {
            string fileFold = parameter.ToString();
            if (!Directory.Exists(fileFold))
            {
                return;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(fileFold);

            foreach (var item in directoryInfo.GetFiles())
            {
                string fileFullName = item.FullName;
                string fileName = item.Name;
                string directoryTemp = Path.Combine(fileFold, "Temp");
                if (!Directory.Exists(directoryTemp))
                {
                    Directory.CreateDirectory(directoryTemp);
                }

                string tempFileFullName = Path.Combine(directoryTemp, fileName);

                SaveCopyAs(fileFullName, tempFileFullName);
            }

            UpdateDgvHandler updateDgvHandler = new UpdateDgvHandler(UpdateDoctorPriceDgv);
            btnBrowns.Invoke(updateDgvHandler);

            MessageBox.Show("文件处理完成!");
        }

        private void UpdateDoctorPriceDgv()
        {
            btnBrowns.Enabled = true;
            btnProcessExcel.Enabled = true;
            procesTime.Enabled = false;
            processBar.Value = processBar.Maximum;
        }

        private void btnProcessExcel_Click(object sender, EventArgs e)
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

            processBar.Value = 0;
            procesTime.Enabled = true;

            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ImportFile);

            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(txtImageFilePath.Text);
            btnBrowns.Enabled = false;
            btnProcessExcel.Enabled = false;
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

        private void procesTime_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (processBar.Value < processBar.Maximum)
            {
                processBar.Value += 1;
            }
            else
            {
                processBar.Value = 0;
            }
        }
    }
}
