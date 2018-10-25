using System;
using System.Collections.Generic;
using Elephant;

namespace ImageStatisticsModel
{
    /// <summary>
    /// 按照门店统计
    /// </summary>
    public class StoreStatistics
    {
        /// <summary>
        /// 门店名
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 医生名
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// CT诊断数量
        /// </summary>
        public int CTDiagnosisCount { get; set; }

        /// <summary>
        /// CT终审数量
        /// </summary>
        public int CTAuditCount { get; set; }

        /// <summary>
        /// CT总计
        /// </summary>
        public int CTCount { get; set; }


        /// <summary>
        /// MR诊断数量
        /// </summary>
        public int MRDiagnosisCount { get; set; }

        /// <summary>
        /// MR终审数量
        /// </summary>
        public int MRAuditCount { get; set; }

        /// <summary>
        /// MR总计
        /// </summary>
        public int MRCount { get; set; }

        /// <summary>
        /// DR诊断数量
        /// </summary>
        public int DRDiagnosisCount { get; set; }

        /// <summary>
        /// DR终审数量
        /// </summary>
        public int DRAuditCount { get; set; }

        /// <summary>
        /// DR总计
        /// </summary>
        public int DRCount { get; set; }

        /// <summary>
        /// 在放射医生价格库中是否包含价格
        /// </summary>
        public bool IsContainPrice { get; set; } = false;

        /// <summary>
        /// 医生在指定门店下诊断、终审 各种片子的总价格
        /// </summary>
        public decimal Price { get; set; }
    }
}