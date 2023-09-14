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
    public class EquipmentRepositorySQL : IRepository<Equipment>
    {
        private CarDb db;
        public EquipmentRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Equipment> GetList()
        {
            return db.Equipment.ToList();
        }

        public Equipment GetItem(int id)
        {
            return db.Equipment.Find(id);
        }

        public void Create(Equipment item)
        {
            db.Equipment.Add(item);
        }

        public void Update(Equipment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Equipment item = db.Equipment.Find(id);
            if (item != null)
                db.Equipment.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}