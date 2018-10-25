using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Elephant.Data;
using ImageStatisticsIDAL;
using ImageStatisticsModel;

namespace ImageStatisticsDAL
{
    public class StoreDoctorDetialRepository : EfRepository<StoreDoctorDetial, Guid>, IStoreDoctorDetialRepository
    {
        private ImageStatisticsDbContext _context = null;

        public StoreDoctorDetialRepository(ImageStatisticsDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取到门店、诊断医生、终审医生、检查类型、统计数量
        /// </summary>
        /// <returns></returns>
        public List<StoreDoctorStatistics> GetStoreDoctorStatistics(DateTime startTime, DateTime endTime)
        {
            string sqlQuery = $"select StoreDoctorDetials.StoreName,StoreDoctorDetials.DiagnosisDoctor,StoreDoctorDetials.AuditDoctor,CheckType,count(CheckType) as count from StoreDoctorDetials where CheckTime between '" + startTime + "' and '" + endTime + "' group by StoreDoctorDetials.StoreName, DiagnosisDoctor,AuditDoctor,CheckType";

            var query = _context.Database.SqlQuery<StoreDoctorStatistics>(sqlQuery, new object[] { });
            var result = query.OrderBy(q => q.StoreName).ToList();

            return result;
        }

        public int DeleteStoreDoctorDetials(DateTime startTime, DateTime endTime)
        {
            SqlConnection sqlConnection = this._context.Database.Connection as SqlConnection;

            //TODO::尝试打开三次
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            SqlTransaction tran = sqlConnection.BeginTransaction();
            int rows = -1;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete From StoreDoctorDetials where CheckTime between '" + startTime + "' and '" + endTime + "'");
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = tran;
                rows = sqlCommand.ExecuteNonQuery();

                tran.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rows;
        }

        public int InsertOrgionDataIntoDatabase(DataTable dataTable)
        {
            SqlConnection sqlConnection = this._context.Database.Connection as SqlConnection;

            //TODO::尝试打开三次
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            SqlTransaction tran = sqlConnection.BeginTransaction();
            SqlBulkCopy bulkCopyOrders = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.KeepIdentity, tran);
            bulkCopyOrders.DestinationTableName = nameof(this._context.StoreDoctorDetial) + "s";
            try
            {
                bulkCopyOrders.WriteToServer(dataTable);
                tran.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataTable.Rows.Count;
        }
    }
}