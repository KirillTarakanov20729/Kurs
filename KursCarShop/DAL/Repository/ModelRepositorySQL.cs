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
    public class ModelRepositorySQL : IRepository<Model>
    {
        private CarDb db;
        public ModelRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Model> GetList()
        {
            return db.Model.ToList();
        }

        public Model GetItem(int id)
        {
            return db.Model.Find(id);
        }

        public void Create(Model item)
        {
            db.Model.Add(item);
        }

        public void Update(Model item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Model item = db.Model.Find(id);
            if (item != null)
                db.Model.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}