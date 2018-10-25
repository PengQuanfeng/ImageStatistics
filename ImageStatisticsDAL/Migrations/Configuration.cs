using System.Data.Entity.Migrations;
using ImageStatisticsDAL;

namespace ImageStatisticsDAL
{
    internal sealed class Configuration : DbMigrationsConfiguration<ImageStatisticsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ImageStatisticsDbContext context)
        {
        }
    }
}