using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private CarDb db;
        private CarRepositorySQL carRepository;
        private OrderRepositorySQL orderRepository;
        private EquipmentRepositorySQL equipmentRepository;
        private BrandRepositorySQL brandRepository;
        private UserRepositorySQL userRepository;
        private ModelRepositorySQL modelRepository;
        private ClientRepositorySQL clientRepository;
        private EmployeeRepositorySQL employeeRepository;
        private TypeRepositorySQL typeRepository;
        private ReportRepositorySQL reportRepository;

        public DbReposSQL()
        {
            db = new CarDb();
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepositorySQL(db);
                return carRepository;
            }
        }
        public IRepository<Type> Types
        {
            get
            {
                if (typeRepository == null)
                    typeRepository = new TypeRepositorySQL(db);
                return typeRepository;
            }
        }
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepositorySQL(db);
                return employeeRepository;
            }
        }
        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepositorySQL(db);
                return clientRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(db);
                return userRepository;
            }
        }
        public IRepository<Brand> Brands
        {
            get
            {
                if (brandRepository == null)
                    brandRepository = new BrandRepositorySQL(db);
                return brandRepository;
            }
        }
        public IRepository<Model> Models
        {
            get
            {
                if (modelRepository == null)
                    modelRepository = new ModelRepositorySQL(db);
                return modelRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepositorySQL(db);
                return orderRepository;
            }
        }

        public IRepository<Equipment> Equipments
        {
            get
            {
                if (equipmentRepository == null)
                    equipmentRepository = new EquipmentRepositorySQL(db);
                return equipmentRepository;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepositorySQL(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}