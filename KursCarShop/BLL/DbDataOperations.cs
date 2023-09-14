using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;
using System.Security.Policy;
using System.Diagnostics.Contracts;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL
{

    public class DbDataOperations : IDbCrud
    {
        IDbRepos db;
        public DbDataOperations(IDbRepos repos)
        {
            db = repos;
        }

        public List<CarModel> GetAllCars()
        {
            return db.Cars.GetList().Select(i => new CarModel(i)).ToList();
        }
        public CarModel GetCar(int Id)
        {
            return new CarModel(db.Cars.GetItem(Id));
        }
        public void CreateCar(CarModel p)
        {
            db.Cars.Create(new Car() { id = p.id, price = p.price, equipment_id = p.equipment_id, availability = p.availability, colour = p.colour });
            Save();
        }
        public void DeleteCar(int id)
        {
            if (db.Cars.GetItem(id) != null)
            {
                db.Cars.Delete(id);
                Save();
            }
        }
        public void UpdateCar(CarModel p)
        {
            Car ph = db.Cars.GetItem(p.id);
            ph.price = p.price;
            ph.availability = p.availability;
            ph.colour = p.colour;
            ph.equipment_id = p.equipment_id;
            Save();
        }





        public List<OrderModel> GetAllOrders()
        {
            return db.Orders.GetList().Select(i => new OrderModel(i)).ToList();
        }
        public OrderModel GetOrder(int Id)
        {
            return new OrderModel(db.Orders.GetItem(Id));
        }
        public void CreateOrder(OrderModel p)
        {
            db.Orders.Create(new Order() { id = p.id, car_id = p.car_id, employee_id = p.employee_id, client_id = p.client_id, date = p.date, status = p.status });
            Save();
        }
        public void UpdateOrder(OrderModel p)
        {
            Order ph = db.Orders.GetItem(p.id);
            ph.client_id = p.client_id;
            ph.employee_id = p.employee_id;
            ph.car_id = p.car_id;
            ph.date = p.date;
            ph.status = p.status;
            Save();
        }
        public void DeleteOrder(int id)
        {
            if (db.Orders.GetItem(id) != null)
            {
                db.Orders.Delete(id);
                Save();
            }
        }



        public List<EquipmentModel> GetAllEquipments()
        {
            return db.Equipments.GetList().Select(i => new EquipmentModel(i)).ToList();
        }
        public EquipmentModel GetEquipment(int Id)
        {
            return new EquipmentModel(db.Equipments.GetItem(Id));
        }
        public void CreateEquipment(EquipmentModel p)
        {
            db.Equipments.Create(new Equipment() { id = p.id, model_id = p.model_id, engine_capacity = p.engine_capacity, horsepower = p.horsepower, transmission = p.transmission });
            Save();
        }
        public void UpdateEquipment(EquipmentModel p)
        {
            Equipment ph = db.Equipments.GetItem(p.id);
            ph.transmission = p.transmission;
            ph.horsepower = p.horsepower;
            ph.engine_capacity = p.engine_capacity;
            ph.model_id = p.model_id;
            Save();
        }
        public void DeleteEquipment(int id)
        {
            if (db.Equipments.GetItem(id) != null)
            {
                db.Equipments.Delete(id);
                Save();
            }
        }





        public List<BrandModel> GetAllBrands()
        {
            return db.Brands.GetList().Select(i => new BrandModel(i)).ToList();
        }
        public BrandModel GetBrand(int Id)
        {
            return new BrandModel(db.Brands.GetItem(Id));
        }
        public void CreateBrand(BrandModel p)
        {
            db.Brands.Create(new Brand() { id = p.id, name = p.name });
            Save();
        }
        public void UpdateBrand(BrandModel p)
        {
            Brand ph = db.Brands.GetItem(p.id);
            ph.name = p.name;
            Save();
        }
        public void DeleteBrand(int id)
        {
            if (db.Brands.GetItem(id) != null)
            {
                db.Brands.Delete(id);
                Save();
            }
        }



        public List<EmployeeModel> GetAllEmployees()
        {
            return db.Employees.GetList().Select(i => new EmployeeModel(i)).ToList();
        }

        public EmployeeModel GetEmployee(int Id)
        {
            return new EmployeeModel(db.Employees.GetItem(Id));
        }
        public void CreateEmployee(EmployeeModel p)
        {
            db.Employees.Create(new Employee() { id = p.id, FIO = p.FIO, phone = p.phone, user_id = p.user_id });
            Save();
        }
        public void UpdateEmployee(EmployeeModel p)
        {
            Employee ph = db.Employees.GetItem(p.id);
            ph.FIO = p.FIO;
            ph.phone = p.phone;
            ph.user_id = p.user_id;
            Save();
        }
        public void DeleteEmployee(int id)
        {
            if (db.Employees.GetItem(id) != null)
            {
                db.Employees.Delete(id);
                Save();
            }
        }



        public List<ModelModel> GetAllModels()
        {
            return db.Models.GetList().Select(i => new ModelModel(i)).ToList();
        }

        public ModelModel GetModel(int Id)
        {
            return new ModelModel(db.Models.GetItem(Id));
        }
        public void CreateModel(ModelModel p)
        {
            db.Models.Create(new Model() { id = p.id, brand_id = p.brand_id, name = p.name });
            Save();
        }
        public void UpdateModel(ModelModel p)
        {
            Model ph = db.Models.GetItem(p.id);
            ph.brand_id = p.brand_id;
            ph.name = p.name;
            Save();
        }
        public void DeleteModel(int id)
        {
            if (db.Models.GetItem(id) != null)
            {
                db.Models.Delete(id);
                Save();
            }
        }







        public List<ClientModel> GetAllClients()
        {
            return db.Clients.GetList().Select(i => new ClientModel(i)).ToList();
        }

        public ClientModel GetClient(int Id)
        {
            return new ClientModel(db.Clients.GetItem(Id));
        }

        public void CreateClient(ClientModel p)
        {
            db.Clients.Create(new Client() { id = p.id, FIO = p.FIO, phone = p.phone, user_id = p.user_id });
            Save();
        }
        public void UpdateClient(ClientModel p)
        {
            Client ph = db.Clients.GetItem(p.id);
            ph.FIO = p.FIO;
            ph.phone = p.phone;
            ph.user_id = p.user_id;
            Save();
        }
        public void DeleteClient(int id)
        {
            if (db.Clients.GetItem(id) != null)
            {
                db.Clients.Delete(id);
                Save();
            }
        }




        public List<UserModel> GetAllUsers()
        {
            return db.Users.GetList().Select(i => new UserModel(i)).ToList();
        }
        public UserModel GetUser(int Id)
        {
            return new UserModel(db.Users.GetItem(Id));
        }
        public void CreateUser(UserModel p)
        {
            db.Users.Create(new User() { id = p.id, type_id = p.type_id, email = p.email, password = p.password });
            Save();
        }
        public void UpdateUser(UserModel p)
        {
            User ph = db.Users.GetItem(p.id);
            ph.type_id = p.type_id;
            ph.email = p.email;
            ph.password = p.password;
            Save();
        }
        public void DeleteUser(int id)
        {
            if (db.Users.GetItem(id) != null)
            {
                db.Users.Delete(id);
                Save();
            }
        }








        public List<TypeModel> GetAllTypes()
        {
            return db.Types.GetList().Select(i => new TypeModel(i)).ToList();
        }
        public TypeModel GetType(int Id)
        {
            return new TypeModel(db.Types.GetItem(Id));
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }




    }
}
