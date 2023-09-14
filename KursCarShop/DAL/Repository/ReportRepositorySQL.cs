using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Reports;

namespace DAL
{
    public class ReportRepositorySQL : IReportsRepository
    {
        private CarDb db;
        public ReportRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }
        private class SPResult
        {
            public int Price { get; set; }

            public string Colour { get; set; }

            public bool Availability { get; set; }
        }

        //выполнить ХП
        public List<CarsByPrice> CarsByPrices(int min, int max)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@MinPrice", min);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@MaxPrice", max);
            CarDb db = new CarDb();
            var result = db.Database.SqlQuery<SPResult>("GetCarsInRange @MinPrice,@MaxPrice", new object[] { param1, param2 }).ToList();
            var data = result.GroupBy(i => new { i.Price, i.Colour, i.Availability })
                .Select(i => new CarsByPrice
                {
                    Price = i.Key.Price,
                    Colour = i.Key.Colour,
                    Availability = i.Key.Availability

                }).ToList();
            return data;
        }

        public List<CarsByHorse> CarsByHorse(int horsepower)
        {
            CarDb db = new CarDb();

            var request = db.Car
                .Join(db.Equipment, car => car.equipment_id, equip => equip.id, (car, equip) => new { Car = car, Equipment = equip })
                .Where(e => e.Equipment.horsepower == horsepower)
                .Select(i => new CarsByHorse() { Price = i.Car.price, Colour = i.Car.colour, Availability = i.Car.availability })
                .ToList();

            return request;
        }

    }
}
