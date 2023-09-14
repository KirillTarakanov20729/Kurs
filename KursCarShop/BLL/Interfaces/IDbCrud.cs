using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud

    {

        List<CarModel> GetAllCars();
        CarModel GetCar(int Id);
        void CreateCar(CarModel p);
        void UpdateCar(CarModel p);
        void DeleteCar(int id);



        List<OrderModel> GetAllOrders();
        OrderModel GetOrder(int Id);
        void CreateOrder(OrderModel p);
        void UpdateOrder(OrderModel p);
        void DeleteOrder(int id);


        List<EquipmentModel> GetAllEquipments();
        EquipmentModel GetEquipment(int Id);
        void CreateEquipment(EquipmentModel p);
        void UpdateEquipment(EquipmentModel p);
        void DeleteEquipment(int id);


        List<BrandModel> GetAllBrands();
        BrandModel GetBrand(int Id);
        void CreateBrand(BrandModel p);
        void UpdateBrand(BrandModel p);
        void DeleteBrand(int id);



        List<ModelModel> GetAllModels();
        ModelModel GetModel(int Id);
        void CreateModel(ModelModel p);
        void UpdateModel(ModelModel p);
        void DeleteModel(int id);


        List<UserModel> GetAllUsers();
        UserModel GetUser(int Id);
        void CreateUser(UserModel p);
        void UpdateUser(UserModel p);
        void DeleteUser(int id);


        List<ClientModel> GetAllClients();
        ClientModel GetClient(int Id);
        void CreateClient(ClientModel p);
        void UpdateClient(ClientModel p);
        void DeleteClient(int id);


        List<EmployeeModel> GetAllEmployees();
        EmployeeModel GetEmployee(int Id);
        void CreateEmployee(EmployeeModel p);
        void UpdateEmployee(EmployeeModel p);
        void DeleteEmployee(int id);



        List<TypeModel> GetAllTypes();
        TypeModel GetType(int Id);



    }
}
