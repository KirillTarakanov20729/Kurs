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
using KursCarShop.Models;

namespace KursCarShop.Orders
{
    /// <summary>
    /// Логика взаимодействия для IndexOrderWindow.xaml
    /// </summary>
    public partial class IndexOrderWindow : Window
    {
        IDbCrud crudServ;
        private List<OrderModel> orderList;
        public IndexOrderWindow(IDbCrud crudServ)
        {
            InitializeComponent();
            this.crudServ = crudServ;
            loadOrders();
        }

        private void loadOrders()
        {
            orderList = crudServ.GetAllOrders();
            foreach (var order in orderList)
            {
                order.Car = crudServ.GetCar(order.car_id);
                order.Car.Equipment = crudServ.GetEquipment(order.Car.equipment_id);
                order.Car.Equipment.Model = crudServ.GetModel(order.Car.Equipment.model_id);
                order.Car.Equipment.Model.Brand = crudServ.GetBrand(order.Car.Equipment.Model.brand_id);
                order.Client = crudServ.GetClient(order.client_id);
                order.Employee = crudServ.GetEmployee(order.employee_id);  
            }
            DisplayOrders(orderList);
        }

        public void DisplayOrders(List<OrderModel> orders)
        {
            orderDataGrid.ItemsSource = orders;
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow createOrderWindow = new CreateOrderWindow(crudServ);
            createOrderWindow.ShowDialog();

            if (createOrderWindow.IsOrderCreated)
            {
                loadOrders();
            }
        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            OrderModel selectedOrder = (OrderModel)orderDataGrid.SelectedItem;
            if (selectedOrder != null)
            {
                UpdateOrderWindow updateOrderWindow = new UpdateOrderWindow(crudServ, selectedOrder);
                updateOrderWindow.ShowDialog();

                if (updateOrderWindow.IsOrderUpdated)
                {
                    loadOrders();
                }
            }
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            OrderModel selectedOrder = (OrderModel)orderDataGrid.SelectedItem;
            if (selectedOrder != null)
            {
                crudServ.DeleteOrder(selectedOrder.id);
                loadOrders();
            }
        }

        private void CloseOrder(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
