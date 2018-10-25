using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageStatisticsModel;

namespace ImageStatisticsIBLL
{
    public interface IImportFileService
    {
        List<StoreDoctorDetial> ImportStoreDoctor(string fileFullName);

        DataTable GetDataTableFromExcelFile(string fileFullName, string sheetName);

        List<StoreDoctorDetial> GetStoreDoctorDetialList(DataTable table);

        void InsertOrgionDataIntoDatabase(List<StoreDoctorDetial> list);

        int InsertOrgionDataIntoDatabase(DataTable dataTable);

        Dictionary<string, List<DoctorStatistics>> GetStoreDoctorDetialDic(DateTime startTime, DateTime endTime);

        int DeleteStoreDoctorDetail(DateTime startTime, DateTime endTime);

        bool Export(DataTable[] dataTableArray, string fileFullName);

        DoctorPriceDetial FindDoctorPriceById(Guid guid);

        void CreateDoctorPriceDetial(DoctorPriceDetial doctorPriceDetial);

        void UpdteDoctorPriceDetial(DoctorPriceDetial doctorPriceDetial);


        List<DoctorPriceDetial> GetDoctorPriceDetialList(DataTable table);

        void InsertDoctorPriceDataIntoDatabase(List<DoctorPriceDetial> list);

        DoctorPriceDetial GetDoctorPriceDetial(string doctorName);

        List<DoctorPriceDetial> GetDoctorPriceDetialList();
    }
}
