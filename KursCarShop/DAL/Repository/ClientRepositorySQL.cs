﻿using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ClientRepositorySQL : IRepository<Client>
    {
        private CarDb db;
        public ClientRepositorySQL(CarDb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Client> GetList()
        {
            return db.Client.ToList();
        }

        public Client GetItem(int id)
        {
            return db.Client.Find(id);
        }

        public void Create(Client item)
        {
            db.Client.Add(item);
        }

        public void Update(Client item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Client item = db.Client.Find(id);
            if (item != null)
                db.Client.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
