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
    public class BrandRepositorySQL : IRepository<Brand>
    {
        private CarDb db;
        public BrandRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Brand> GetList()
        {
            return db.Brand.ToList();
        }

        public Brand GetItem(int id)
        {
            return db.Brand.Find(id);
        }

        public void Create(Brand item)
        {
            db.Brand.Add(item);
        }

        public void Update(Brand item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Brand item = db.Brand.Find(id);
            if (item != null)
                db.Brand.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
