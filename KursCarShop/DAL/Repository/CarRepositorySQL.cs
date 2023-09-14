using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CarRepositorySQL : IRepository<Car>
    {
        private CarDb db;
        public CarRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Car> GetList()
        {
            return db.Car.ToList();
        }

        public Car GetItem(int id)
        {
            return db.Car.Find(id);
        }

        public void Create(Car item)
        {
            db.Car.Add(item);
        }

        public void Update(Car item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Car item = db.Car.Find(id);
            if (item != null)
                db.Car.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
