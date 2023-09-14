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
    public class TypeRepositorySQL : IRepository<Type>
    {
        private CarDb db;
        public TypeRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Type> GetList()
        {
            return db.Type.ToList();
        }

        public Type GetItem(int id)
        {
            return db.Type.Find(id);
        }

        public void Create(Type item)
        {
            db.Type.Add(item);
        }

        public void Update(Type item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Type item = db.Type.Find(id);
            if (item != null)
                db.Type.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}