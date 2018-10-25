using System;
using System.Collections.Generic;
using System.Data;
using Elephant;
using ImageStatisticsModel;

namespace ImageStatisticsIDAL
{
    public interface IStoreDoctorDetialRepository : IRepository<StoreDoctorDetial, Guid>
    {

        /// <summary>
        /// 获取到门店、诊断医生、终审医生、检查类型、统计数量
        /// </summary>
        /// <returns></returns>

        List<StoreDoctorStatistics> GetStoreDoctorStatistics(DateTime startTime, DateTime endTime);

        int DeleteStoreDoctorDetials(DateTime startTime, DateTime endTime);

        int InsertOrgionDataIntoDatabase(DataTable dataTable);

    }
}