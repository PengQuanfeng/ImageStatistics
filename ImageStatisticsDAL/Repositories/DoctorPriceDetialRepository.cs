using System;
using System.Collections.Generic;
using System.Linq;
using Elephant.Data;
using ImageStatisticsIDAL;
using ImageStatisticsModel;

namespace ImageStatisticsDAL
{
    public class DoctorPriceDetialRepository : EfRepository<DoctorPriceDetial, Guid>, IDoctorPriceDetialRepository
    {
        private ImageStatisticsDbContext _context = null;

        public DoctorPriceDetialRepository(ImageStatisticsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}