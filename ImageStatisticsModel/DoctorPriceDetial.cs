using System;
using Elephant;

namespace ImageStatisticsModel
{
    /// <summary>
    /// 医生阅片单价汇总												
    /// </summary>
    public class DoctorPriceDetial : Entity<Guid>, IAggregateRoot<Guid>
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// 门店   默认为空
        /// </summary>
        public string StoreName { get; set; } = string.Empty;

        /// <summary>
        /// 医生
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// CT诊断（元/张）
        /// </summary>
        public string CTDiagnosisPrice { get; set; }

        /// <summary>
        /// MRI诊断（元/张）
        /// </summary>
        public string MRDiagnosisPrice { get; set; }

        /// <summary>
        /// DR诊断（元/张）
        /// </summary>
        public string DRDiagnosisPrice { get; set; }

        /// <summary>
        /// CT核片（元/张）
        /// </summary>
        public string CTAuditPrice { get; set; }

        /// <summary>
        /// MR核片（元/张）
        /// </summary>
        public string MRAuditPrice { get; set; }

        ///// <summary>
        ///// DR核片（元/张）
        ///// </summary>
        //public string DRAuditPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}