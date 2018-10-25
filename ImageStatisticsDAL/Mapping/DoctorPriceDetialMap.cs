using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ImageStatisticsModel;

namespace ImageStatisticsDAL
{
    public class DoctorPriceDetialMap : EntityTypeConfiguration<DoctorPriceDetial>
    {
        public DoctorPriceDetialMap()
        {
            HasKey(s => s.Id).Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}