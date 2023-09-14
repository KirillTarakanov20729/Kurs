using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Models.ReportModels;

namespace BLL
{
    public class ReportsService : IReportService
    {
        private IDbRepos db;
        public ReportsService(IDbRepos repos)
        {
            db = repos;
        }

        //выполнить ХП
        public List<CarsByPrice> CarsByPrices(int min, int max)
        {

            return db.Reports.CarsByPrices(min, max).Select(i => new CarsByPrice { Price = i.Price, Colour = i.Colour, Availability = i.Availability }).ToList();
        }

        public List<CarsByHorse> CarsByHorse(int horsepower)
        {
            var request = db.Reports.CarsByHorse(horsepower)
             .Select(i => new CarsByHorse() { Price = i.Price, Colour = i.Colour, Availability = i.Availability })
             .ToList();
            return request;
        }
    }
}
