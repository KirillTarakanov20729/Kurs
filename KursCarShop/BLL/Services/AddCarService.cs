using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddCarService: IAddCarService
    {
        CarDb db;

        public AddCarService()
        {
            db = new CarDb();
        }

        public void AddCar(CarModel car)
        {
            decimal sum = new Discount(0.05m).GetDiscountedPrice(car.price);

            Car newCar = new Car
            {
                id = car.id,
                equipment_id = car.equipment_id,
                price = (int)sum,
                colour = car.colour,
                availability = car.availability,
            };

            db.Car.Add(newCar);
            db.SaveChanges();
        }
    }
}
