using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elephant;

namespace ImageStatisticsModel
{
    public class StoreDoctorDetial : Entity<Guid>, IAggregateRoot<Guid>
    {
        /// <summary>
        /// 序号
        /// </summary>
        [Description("序号")]
        public int No { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Description("姓名")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Sex { get; set; } = string.Empty;

        /// <summary>
        /// 年龄
        /// </summary>
        [Description("年龄")]
        public string Age { get; set; } = string.Empty;

        /// <summary>
        /// 医疗状态
        /// </summary>
        [Description("医疗状态")]
        public string MedicalStatus { get; set; } = string.Empty;

        /// <summary>
        /// 影像号
        /// </summary>
        [Description("影像号")]
        public string ImageNo { get; set; } = string.Empty;

        /// <summary>
        /// 检查号
        /// </summary>
        [Description("检查号")]
        public string CheckNo { get; set; } = string.Empty;

        /// <summary>
        /// 检查类型
        /// </summary>
        [Description("检查类型")]
        public string CheckType { get; set; } = string.Empty;

        /// <summary>
        /// 体检号
        /// </summary>
        [Description("体检号")]
        public string ExaminationNo { get; set; } = string.Empty;

        /// <summary>
        /// 检查部位
        /// </summary>
        [Description("检查部位")]
        public string CheckPart { get; set; } = string.Empty;

        /// <summary>
        /// 检查项目
        /// </summary>
        [Description("检查项目")]
        public string CheckProject { get; set; } = string.Empty;

        /// <summary>
        /// 阴阳性
        /// </summary>
        [Description("阴阳性")]
        public string CheckResult { get; set; } = string.Empty;

        /// <summary>
        /// 登记时间
        /// </summary>
        [Description("登记时间")]
        public DateTime? RegistrationTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 操作技师
        /// </summary>
        [Description("操作技师")]
        public string Operator { get; set; } = string.Empty;

        /// <summary>
        /// 检查时间
        /// </summary>
        [Description("检查时间")]
        public DateTime? CheckTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 诊断医生
        /// </summary>
        [Description("诊断医生")]
        public string DiagnosisDoctor { get; set; } = string.Empty;

        /// <summary>
        /// 诊断时间
        /// </summary>
        [Description("诊断时间")]
        public DateTime? DiagnosisTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 终审医生
        /// </summary>
        [Description("终审医生")]
        public string AuditDoctor { get; set; } = string.Empty;

        /// <summary>
        /// 终审时间
        /// </summary>
        [Description("终审时间")]
        public DateTime? AuditTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 申请科室
        /// </summary>
        [Description("申请科室")]

        public string StoreName { get; set; } = string.Empty;

        [Description("文件名")]
        public string FileName { get; set; } = string.Empty;
    }
}
