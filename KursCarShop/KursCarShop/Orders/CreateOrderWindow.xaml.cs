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
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        IDbCrud db;
        public OrderModel NewOrder = new OrderModel();
        public bool IsOrderCreated { get; private set; } = false;
        public CreateOrderWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBoxClients();
            FillComboBoxEmployees();
            FillComboBoxCars();
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
            foreach ( CarModel car in cars )
            {
                car.Equipment = db.GetEquipment(car.equipment_id);
                car.Equipment.Model = db.GetModel(car.Equipment.model_id);
                car.Equipment.Model.Brand = db.GetBrand(car.Equipment.Model.brand_id);
            }
            Car_id.ItemsSource = cars;
            Car_id.DisplayMemberPath = "DisplayString";
        }

        private void CreateOrderSave(object sender, RoutedEventArgs e)
        {
            int newOrderID = db.GetAllClients().Max(car => car.id) + 1;
            int carID = ((CarModel)Car_id.SelectedItem).id;
            int clientID = ((ClientModel)Client_id.SelectedItem).id;
            int employeeID = ((EmployeeModel)Employee_id.SelectedItem).id;
            bool status = (bool)statusCheckBox.IsChecked;
            DateTime date = (DateTime)dateOrder.SelectedDate;


            NewOrder.id = newOrderID;
            NewOrder.car_id = carID;
            NewOrder.client_id = clientID;
            NewOrder.employee_id = employeeID;
            db.CreateOrder(NewOrder);

            IsOrderCreated = true;
            Close();
        }
    }
}
