using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Elephant.Document;
using ImageStatisticsDAL;
using ImageStatisticsIBLL;
using ImageStatisticsIDAL;
using ImageStatisticsModel;
using NLog;

namespace ImageStatisticsBLL
{
    public class ImportFileService : IImportFileService
    {
        private IStoreDoctorDetialRepository _storeDoctorDetialRepository;
        private IDoctorPriceDetialRepository _doctorPriceDetialRepository;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ImportFileService()
        {
            var dbContext = new ImageStatisticsDbContext();

            _storeDoctorDetialRepository = new StoreDoctorDetialRepository(dbContext);
            _doctorPriceDetialRepository = new DoctorPriceDetialRepository(dbContext);
        }

        private string ConvertDataRow(object row)
        {
            return row != DBNull.Value ? row.ToString() : "";
        }

        private DateTime? GetDateTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                return new DateTime?();
            }

            try
            {
                DateTime? date = Convert.ToDateTime(time);
                return date;
            }
            catch
            {
                return new DateTime?();
            }
        }

        public List<StoreDoctorDetial> ImportStoreDoctor(string fileFullName)
        {
            if (string.IsNullOrEmpty(fileFullName))
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(fileFullName))
            {
                throw new ArgumentException("不存在文件!");
            }


            DataTable table = GetDataTableFromExcelFile(fileFullName, string.Empty);

            List<StoreDoctorDetial> list = GetStoreDoctorDetialList(table);

            return list;
        }

        public List<StoreDoctorDetial> GetStoreDoctorDetialList(DataTable table)
        {
            var storeDoctorDetialList = new List<StoreDoctorDetial>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                try
                {

                    if (string.IsNullOrEmpty(ConvertDataRow(row["序号"])))
                    {
                        /// table.Rows.Remove(row);
                    }

                    StoreDoctorDetial storeDoctorDetial = new StoreDoctorDetial
                    {
                        No = int.Parse(ConvertDataRow(row["序号"])),
                        Name = ConvertDataRow(row["姓名"]),
                        Sex = ConvertDataRow(row["性别"]),
                        Age = ConvertDataRow(row["年龄"]),
                        MedicalStatus = ConvertDataRow(row["医疗状态"]),
                        ImageNo = ConvertDataRow(row["影像号"]),
                        CheckNo = ConvertDataRow(row["检查号"]),
                        CheckType = ConvertDataRow(row["检查类型"]),
                        ExaminationNo = ConvertDataRow(row["体检号"]),
                        CheckPart = ConvertDataRow(row["检查部位"]),
                        CheckProject = ConvertDataRow(row["检查项目"]),
                        CheckResult = ConvertDataRow(row["阴阳性"]),
                        RegistrationTime = GetDateTime(ConvertDataRow(row["登记时间"])).Value,
                        Operator = ConvertDataRow(row["操作技师"]),
                        CheckTime = GetDateTime(ConvertDataRow(row["检查时间"])).Value,
                        DiagnosisDoctor = ConvertDataRow(row["诊断医生"]),
                        DiagnosisTime = GetDateTime(ConvertDataRow(row["诊断时间"])).Value,
                        AuditDoctor = ConvertDataRow(row["终审医生"]),
                        AuditTime = GetDateTime(ConvertDataRow(row["终审时间"])).Value,
                        StoreName = ConvertDataRow(row["申请科室"]),
                    };

                    storeDoctorDetialList.Add(storeDoctorDetial);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Logger.Info($"调用函数GetStoreDoctorDetialList失败！" + ex.Message);
                    Logger.Info($"调用函数GetStoreDoctorDetialList失败！" + ex.StackTrace);
                }
            }

            return storeDoctorDetialList;
        }

        public DataTable GetDataTableFromExcelFile(string fileFullName, string sheetName)
        {
            if (string.IsNullOrEmpty(fileFullName))
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(fileFullName))
            {
                throw new ArgumentException("不存在文件!");
            }

            DataTable table = null;

            try
            {
                if (string.IsNullOrEmpty(sheetName))
                {
                    table = ExcelHelper.Read(fileFullName, true).Tables[0];
                }
                else
                {
                    table = ExcelHelper.Read(fileFullName, sheetName, true).Tables[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Info($"调用函数GetDataTableFromExcelFile失败！" + ex.Message);
                Logger.Info($"调用函数GetDataTableFromExcelFile失败！" + ex.StackTrace);

                return table;
            }


            return table;
        }

        public void InsertOrgionDataIntoDatabase(List<StoreDoctorDetial> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                StoreDoctorDetial storeDoctorDetial = list[i];

                if (_storeDoctorDetialRepository.Find(s => s.ImageNo.Equals(storeDoctorDetial.ImageNo) && s.CheckNo.Equals(storeDoctorDetial.CheckNo) && s.CheckPart.Equals(storeDoctorDetial.CheckPart) && s.CheckProject.Equals(storeDoctorDetial.CheckProject) && s.ExaminationNo.Equals(storeDoctorDetial.ExaminationNo)).Count() >= 1)
                {
                    List<StoreDoctorDetial> findedStoreDoctorDetial = _storeDoctorDetialRepository.Find(s => s.ImageNo.Equals(storeDoctorDetial.ImageNo) && s.CheckNo.Equals(storeDoctorDetial.CheckNo) && s.CheckPart.Equals(storeDoctorDetial.CheckPart) && s.CheckProject.Equals(storeDoctorDetial.CheckProject) && s.ExaminationNo.Equals(storeDoctorDetial.ExaminationNo)).ToList();
                    foreach (var item in findedStoreDoctorDetial)
                    {
                        //findedStoreDoctorDetial.ImageNo = storeDoctorDetial.ImageNo;
                        //findedStoreDoctorDetial.MedicalStatus = storeDoctorDetial.MedicalStatus;
                        //findedStoreDoctorDetial.Name = storeDoctorDetial.Name;
                        //findedStoreDoctorDetial.No = storeDoctorDetial.No;
                        //findedStoreDoctorDetial.Operator = storeDoctorDetial.Operator;
                        //findedStoreDoctorDetial.RegistrationTime = storeDoctorDetial.RegistrationTime;
                        //findedStoreDoctorDetial.Sex = storeDoctorDetial.Sex;
                        item.StoreName = storeDoctorDetial.StoreName;
                        //findedStoreDoctorDetial.ExaminationNo = storeDoctorDetial.ExaminationNo;
                        //findedStoreDoctorDetial.DiagnosisTime = storeDoctorDetial.DiagnosisTime;
                        //findedStoreDoctorDetial.DiagnosisDoctor = storeDoctorDetial.DiagnosisDoctor;
                        //findedStoreDoctorDetial.CheckType = storeDoctorDetial.CheckType;
                        //findedStoreDoctorDetial.CheckTime = storeDoctorDetial.CheckTime;
                        //findedStoreDoctorDetial.CheckResult = storeDoctorDetial.CheckResult;
                        //findedStoreDoctorDetial.CheckProject = storeDoctorDetial.CheckProject;
                        //findedStoreDoctorDetial.CheckPart = storeDoctorDetial.CheckPart;
                        //findedStoreDoctorDetial.CheckNo = storeDoctorDetial.CheckNo;
                        //findedStoreDoctorDetial.AuditTime = storeDoctorDetial.AuditTime;
                        //findedStoreDoctorDetial.AuditDoctor = storeDoctorDetial.AuditDoctor;
                        //findedStoreDoctorDetial.Age = storeDoctorDetial.Age;

                        _storeDoctorDetialRepository.Update(item);
                    }
                }
                else
                {
                    _storeDoctorDetialRepository.Create(storeDoctorDetial);
                }

                if (i % 100 == 0)
                {
                    _storeDoctorDetialRepository.Commit();
                }
            }

            _storeDoctorDetialRepository.Commit();
        }

        public int InsertOrgionDataIntoDatabase(DataTable dataTable)
        {
            int count = _storeDoctorDetialRepository.InsertOrgionDataIntoDatabase(dataTable);

            return count;
        }

        public Dictionary<string, List<DoctorStatistics>> GetStoreDoctorDetialDic(DateTime startTime, DateTime endTime)
        {
            Dictionary<string, List<DoctorStatistics>> dictionary = new Dictionary<string, List<DoctorStatistics>>();

            List<StoreDoctorStatistics> storeDoctorStatisticsList = _storeDoctorDetialRepository.GetStoreDoctorStatistics(startTime, endTime);

            for (int i = 0; i < storeDoctorStatisticsList.Count; i++)
            {
                StoreDoctorStatistics storeDoctorStatistics = storeDoctorStatisticsList[i];
                if (storeDoctorStatistics.StoreName == null)
                {
                    storeDoctorStatistics.StoreName = "";
                }
                if (storeDoctorStatistics.AuditDoctor == null)
                {
                    storeDoctorStatistics.AuditDoctor = "";
                }

                if (storeDoctorStatistics.DiagnosisDoctor == null)
                {
                    storeDoctorStatistics.DiagnosisDoctor = "";
                }


                if (!dictionary.ContainsKey(storeDoctorStatistics.StoreName))
                {
                    List<DoctorStatistics> statisticsList = new List<DoctorStatistics>();

                    DoctorStatistics diagnosisStatistics = new DoctorStatistics();
                    DoctorStatistics statistics = new DoctorStatistics();

                    diagnosisStatistics.DoctorName = storeDoctorStatistics.DiagnosisDoctor;

                    //各种类型的诊断数量
                    if (storeDoctorStatistics.CheckType == CheckType.CT)
                    {
                        diagnosisStatistics.CTDiagnosisCount = storeDoctorStatistics.Count;
                    }
                    if (storeDoctorStatistics.CheckType == CheckType.MR)
                    {
                        diagnosisStatistics.MRDiagnosisCount = storeDoctorStatistics.Count;
                    }
                    if (storeDoctorStatistics.CheckType == CheckType.DR)
                    {
                        diagnosisStatistics.DRDiagnosisCount = storeDoctorStatistics.Count;
                    }

                    //如果此医生是审核医生，则赋值各种类型的审核数量
                    if (diagnosisStatistics.DoctorName.Equals(storeDoctorStatistics.AuditDoctor))
                    {
                        statistics.DoctorName = storeDoctorStatistics.AuditDoctor;
                        if (storeDoctorStatistics.CheckType == CheckType.CT)
                        {
                            diagnosisStatistics.CTAuditCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.MR)
                        {
                            diagnosisStatistics.MRAuditCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.DR)
                        {
                            diagnosisStatistics.DRAuditCount = storeDoctorStatistics.Count;
                        }
                    }
                    else
                    {
                        statistics.DoctorName = storeDoctorStatistics.AuditDoctor;
                        if (storeDoctorStatistics.CheckType == CheckType.CT)
                        {
                            statistics.CTAuditCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.MR)
                        {
                            statistics.MRAuditCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.DR)
                        {
                            statistics.DRAuditCount = storeDoctorStatistics.Count;
                        }
                    }

                    diagnosisStatistics.CTCount = diagnosisStatistics.CTDiagnosisCount + diagnosisStatistics.CTAuditCount;
                    statistics.CTCount = statistics.CTDiagnosisCount + statistics.CTAuditCount;

                    diagnosisStatistics.MRCount = diagnosisStatistics.MRDiagnosisCount + diagnosisStatistics.MRAuditCount;
                    statistics.MRCount = statistics.MRDiagnosisCount + statistics.MRAuditCount;

                    diagnosisStatistics.DRCount = diagnosisStatistics.DRDiagnosisCount + diagnosisStatistics.DRAuditCount;
                    statistics.DRCount = statistics.DRDiagnosisCount + statistics.DRAuditCount;

                    statisticsList.Add(diagnosisStatistics);
                    statisticsList.Add(statistics);

                    dictionary.Add(storeDoctorStatistics.StoreName, statisticsList);

                }
                else
                {
                    List<DoctorStatistics> currentStore = dictionary[storeDoctorStatistics.StoreName];

                    var findDiagnosisStatisticsList = currentStore.FindAll(c => c.DoctorName != null && c.DoctorName.Equals(storeDoctorStatistics.DiagnosisDoctor)); //诊断医生

                    if (findDiagnosisStatisticsList.Count > 0) //诊断医生
                    {
                        var firstFindStatistics = findDiagnosisStatisticsList[0];

                        //各种类型的诊断数量
                        if (storeDoctorStatistics.CheckType == CheckType.CT)
                        {
                            firstFindStatistics.CTDiagnosisCount += storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.MR)
                        {
                            firstFindStatistics.MRDiagnosisCount += storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.DR)
                        {
                            firstFindStatistics.DRDiagnosisCount += storeDoctorStatistics.Count;
                        }

                        firstFindStatistics.CTCount = firstFindStatistics.CTDiagnosisCount + firstFindStatistics.CTAuditCount;
                        firstFindStatistics.MRCount = firstFindStatistics.MRDiagnosisCount + firstFindStatistics.MRAuditCount;
                        firstFindStatistics.DRCount = firstFindStatistics.DRDiagnosisCount + firstFindStatistics.DRAuditCount;
                    }
                    else
                    {
                        DoctorStatistics diagonsisStatistics = new DoctorStatistics(); //诊断医生

                        diagonsisStatistics.DoctorName = storeDoctorStatistics.DiagnosisDoctor;

                        //各种类型的诊断数量
                        if (storeDoctorStatistics.CheckType == CheckType.CT)
                        {
                            diagonsisStatistics.CTDiagnosisCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.MR)
                        {
                            diagonsisStatistics.MRDiagnosisCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.DR)
                        {
                            diagonsisStatistics.DRDiagnosisCount = storeDoctorStatistics.Count;
                        }


                        diagonsisStatistics.CTCount = diagonsisStatistics.CTDiagnosisCount + diagonsisStatistics.CTAuditCount;
                        diagonsisStatistics.MRCount = diagonsisStatistics.MRDiagnosisCount + diagonsisStatistics.MRAuditCount;
                        diagonsisStatistics.DRCount = diagonsisStatistics.DRDiagnosisCount + diagonsisStatistics.DRAuditCount;

                        currentStore.Add(diagonsisStatistics);
                    }

                    var findAuditStatisticsList = currentStore.FindAll(c => c.DoctorName != null && c.DoctorName.Equals(storeDoctorStatistics.AuditDoctor));//终审医生

                    if (findAuditStatisticsList.Count > 0) //终审医生
                    {
                        var firstFindStatistics = findAuditStatisticsList[0];

                        //如果此医生是审核医生，则赋值各种类型的审核数量
                        if (storeDoctorStatistics.CheckType == CheckType.CT)
                        {
                            firstFindStatistics.CTAuditCount += storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.MR)
                        {
                            firstFindStatistics.MRAuditCount += storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.DR)
                        {
                            firstFindStatistics.DRAuditCount += storeDoctorStatistics.Count;
                        }

                        firstFindStatistics.CTCount = firstFindStatistics.CTDiagnosisCount + firstFindStatistics.CTAuditCount;
                        firstFindStatistics.MRCount = firstFindStatistics.MRDiagnosisCount + firstFindStatistics.MRAuditCount;
                        firstFindStatistics.DRCount = firstFindStatistics.DRDiagnosisCount + firstFindStatistics.DRAuditCount;
                    }
                    else
                    {
                        DoctorStatistics auditStatistics = new DoctorStatistics(); //终审医生

                        auditStatistics.DoctorName = storeDoctorStatistics.AuditDoctor;

                        if (storeDoctorStatistics.CheckType == CheckType.CT)
                        {
                            auditStatistics.CTAuditCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.MR)
                        {
                            auditStatistics.MRAuditCount = storeDoctorStatistics.Count;
                        }
                        if (storeDoctorStatistics.CheckType == CheckType.DR)
                        {
                            auditStatistics.DRAuditCount = storeDoctorStatistics.Count;
                        }

                        auditStatistics.CTCount = auditStatistics.CTDiagnosisCount + auditStatistics.CTAuditCount;
                        auditStatistics.MRCount = auditStatistics.MRDiagnosisCount + auditStatistics.MRAuditCount;
                        auditStatistics.DRCount = auditStatistics.DRDiagnosisCount + auditStatistics.DRAuditCount;

                        currentStore.Add(auditStatistics);
                    }
                }
            }

            return dictionary;
        }

        public int DeleteStoreDoctorDetail(DateTime startTime, DateTime endTime)
        {
            int rows = _storeDoctorDetialRepository.DeleteStoreDoctorDetials(startTime, endTime);
            return rows;
        }

        public bool Export(DataTable[] dataTableArray, string fileFullName)
        {
            try
            {
                ExcelHelper.Write(dataTableArray, fileFullName, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Logger.Info($"调用函数Export失败！" + ex.Message);
                Logger.Info($"调用函数Export失败！" + ex.StackTrace);
                return false;
            }

            return true;
        }


        public DoctorPriceDetial FindDoctorPriceById(Guid guid)
        {
            DoctorPriceDetial doctorPriceDetial = _doctorPriceDetialRepository.FindById(guid);
            return doctorPriceDetial;
        }

        public void CreateDoctorPriceDetial(DoctorPriceDetial doctorPriceDetial)
        {
            if (FindDoctorPriceById(doctorPriceDetial.Id) == null)
            {
                _doctorPriceDetialRepository.Create(doctorPriceDetial);
                _doctorPriceDetialRepository.Commit();
            }
        }

        public void UpdteDoctorPriceDetial(DoctorPriceDetial doctorPriceDetial)
        {
            var result = FindDoctorPriceById(doctorPriceDetial.Id);
            if (result != null)
            {
                result.No = doctorPriceDetial.No;
                result.CTDiagnosisPrice = doctorPriceDetial.CTDiagnosisPrice;
                result.CTAuditPrice = doctorPriceDetial.CTAuditPrice;
                result.MRDiagnosisPrice = doctorPriceDetial.MRDiagnosisPrice;
                result.MRAuditPrice = doctorPriceDetial.MRAuditPrice;
                result.DRDiagnosisPrice = doctorPriceDetial.DRDiagnosisPrice;
                result.DoctorName = doctorPriceDetial.DoctorName;
                result.Note = doctorPriceDetial.Note;

                _doctorPriceDetialRepository.Update(result);
                _doctorPriceDetialRepository.Commit();
            }
        }


        public List<DoctorPriceDetial> GetDoctorPriceDetialList(DataTable table)
        {
            var doctorPriceDetialList = new List<DoctorPriceDetial>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                try
                {

                    if (string.IsNullOrEmpty(ConvertDataRow(row["序号"])))
                    {
                        /// table.Rows.Remove(row);
                    }

                    DoctorPriceDetial doctorPriceDetial = new DoctorPriceDetial
                    {
                        No = int.Parse(ConvertDataRow(row["序号"])),
                        DoctorName = ConvertDataRow(row["医生"]),
                        CTDiagnosisPrice = ConvertDataRow(row["CT诊断（元/张）"]),
                        CTAuditPrice = ConvertDataRow(row["CT核片（元/张）"]),
                        MRDiagnosisPrice = ConvertDataRow(row["MRI诊断（元/张）"]),
                        MRAuditPrice = ConvertDataRow(row["MRI核片（元/张）"]),
                        DRDiagnosisPrice = ConvertDataRow(row["DR诊断（元/张）"]),
                        //DRAuditPrice = ConvertDataRow(row["DR核片（元/张）"]),
                        Note = ConvertDataRow(row["备注"])
                    };

                    doctorPriceDetialList.Add(doctorPriceDetial);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    break;
                }
            }

            return doctorPriceDetialList;
        }

        public void InsertDoctorPriceDataIntoDatabase(List<DoctorPriceDetial> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DoctorPriceDetial doctorPriceDetial = list[i];

                _doctorPriceDetialRepository.Create(doctorPriceDetial);

                if (i % 100 == 0) { _doctorPriceDetialRepository.Commit(); }
            }

            _doctorPriceDetialRepository.Commit();
        }

        public DoctorPriceDetial GetDoctorPriceDetial(string doctorName)
        {
            var doctorPriceDetial = _doctorPriceDetialRepository.Find(d => d.DoctorName.Equals(doctorName)).FirstOrDefault();
            return doctorPriceDetial;
        }

        public List<DoctorPriceDetial> GetDoctorPriceDetialList()
        {
            var doctorPriceDetialList = _doctorPriceDetialRepository.FindAll();
            return doctorPriceDetialList.ToList();
        }
    }
}