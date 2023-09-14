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
    public class EmployeeRepositorySQL : IRepository<Employee>
    {
        private CarDb db;
        public EmployeeRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Employee> GetList()
        {
            return db.Employee.ToList();
        }

        public Employee GetItem(int id)
        {
            return db.Employee.Find(id);
        }

        public void Create(Employee item)
        {
            db.Employee.Add(item);
        }

        public void Update(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Employee item = db.Employee.Find(id);
            if (item != null)
                db.Employee.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
