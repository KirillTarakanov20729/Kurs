using BLL.Interfaces;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursCarShop.Orders
{
    /// <summary>
    /// Логика взаимодействия для UpdateOrderWindow.xaml
    /// </summary>
    public partial class UpdateOrderWindow : Window
    {
        IDbCrud db;
        public OrderModel NewOrder = new OrderModel();
        List<CarModel> cars;
        List<ClientModel> clients;
        List<EmployeeModel> employees;
        private int orderIdToUpdate;

        public bool IsOrderUpdated { get; private set; } = false;
        public UpdateOrderWindow(IDbCrud dbOperations, OrderModel orderToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBoxClients();
            FillComboBoxEmployees();
            FillComboBoxCars();
            LoadOrderData(orderToUpdate);
            orderIdToUpdate = orderToUpdate.id;
        }


        private void LoadOrderData(OrderModel order)
        {
            cars = db.GetAllCars();
            clients = db.GetAllClients();
            employees = db.GetAllEmployees();
            int index1 = cars.FindIndex(car => car.id == order.car_id);
            Car_id.SelectedIndex = index1;
            int index2 = clients.FindIndex(client => client.id == order.client_id);
            Client_id.SelectedIndex = index2;
            int index3 = employees.FindIndex(employee => employee.id == order.employee_id);
            Employee_id.SelectedIndex = index3;
            statusCheckBox.IsChecked = order.status;
            dateOrder.SelectedDate = order.date;
        }

        private void FillComboBoxClients()
        {
            List<ClientModel> clients = db.GetAllClients();

            Client_id.ItemsSource = clients;
            Client_id.DisplayMemberPath = "FIO";
        }

        private void FillComboBoxEmployees()
        {
            List<EmployeeModel> employees = db.GetAllEmployees();

            Employee_id.ItemsSource = employees;
            Employee_id.DisplayMemberPath = "FIO";
        }

        private void FillComboBoxCars()
        {
            List<CarModel> cars = db.GetAllCars();
            foreach (CarModel car in cars)
            {
             
                    car.Equipment = db.GetEquipment(car.equipment_id);
                    car.Equipment.Model = db.GetModel(car.Equipment.model_id);
                    car.Equipment.Model.Brand = db.GetBrand(car.Equipment.Model.brand_id);
                
            }
            Car_id.ItemsSource = cars;
            Car_id.DisplayMemberPath = "DisplayString";
        }

        private void UpdateOrderSave(object sender, RoutedEventArgs e)
        {
            int carID = ((CarModel)Car_id.SelectedItem).id;
            int clientID = ((ClientModel)Client_id.SelectedItem).id;
            int employeeID = ((EmployeeModel)Employee_id.SelectedItem).id;
            DateTime date = (DateTime)dateOrder.SelectedDate;
            bool status = (bool)statusCheckBox.IsChecked;

            NewOrder.id = orderIdToUpdate;
            NewOrder.car_id = carID;
            NewOrder.client_id = clientID;
            NewOrder.employee_id = employeeID;
            NewOrder.date = date;
            NewOrder.status = status;


            db.UpdateOrder(NewOrder);

            IsOrderUpdated = true;
            Close();
        }
    }
}
