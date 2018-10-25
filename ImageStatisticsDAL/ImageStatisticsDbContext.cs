using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ImageStatisticsModel;

namespace ImageStatisticsDAL
{
    public class ImageStatisticsDbContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“OPSDbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Elephant.OPS.EntityFramework.ImageStatisticsDbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“OPSDbContext”
        //连接字符串。
        public ImageStatisticsDbContext()
            : base("name=ImageStatisticsDbContext")
        {
            var traceSource = new TraceSource("SQL");
            Database.Log = msg => traceSource.TraceEvent(TraceEventType.Information, 0, msg);
        }

        /// <summary>
        /// 门店检查数据
        /// </summary>
        public virtual DbSet<StoreDoctorDetial> StoreDoctorDetial { get; set; }

        /// <summary>
        /// 医生阅片单价汇总
        /// </summary>
        public virtual DbSet<DoctorPriceDetial> DoctorPriceDetial { get; set; }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}