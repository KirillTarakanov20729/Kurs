using BLL;
using BLL.Interfaces;
using KursCarShop.Brands;
using KursCarShop.Equipments;
using KursCarShop.Models;
using KursCarShop.Orders;
using KursCarShop.Reports;
using KursCarShop.Users;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursCarShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDbCrud crudServ;
        IAddCarService addcarservice;
        IReportService reportservice;
        private List<CarModel> carsList;


        public MainWindow(IDbCrud crudDb, IAddCarService addcarservice, IReportService reportservice)
        {
            InitializeComponent();
            this.crudServ = crudDb;

            LoadCars();
            this.addcarservice = addcarservice;
            this.reportservice = reportservice;
        }

        private void LoadCars()
        {
            carsList = crudServ.GetAllCars();
            foreach (var car in carsList)
            {
                car.Equipment = crudServ.GetEquipment(car.equipment_id);
                car.Equipment.Model = crudServ.GetModel(car.Equipment.model_id);
                car.Equipment.Model.Brand = crudServ.GetBrand(car.Equipment.Model.brand_id);
            }
            DisplayCars(carsList);
        }

        public void DisplayCars(List<CarModel> cars)
        {
            carDataGrid.ItemsSource = cars;
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            CreateCarWindow createCarWindow = new CreateCarWindow(crudServ, addcarservice);
            createCarWindow.ShowDialog();

            if (createCarWindow.IsCarCreated)
            {
                LoadCars();
            }
        }

        private void UpdateCar(object sender, RoutedEventArgs e)
        {
            CarModel selectedCar = (CarModel)carDataGrid.SelectedItem;
            if (selectedCar != null)
            {
                UpdateCarWindow updateCarWindow = new UpdateCarWindow(crudServ, selectedCar);
                updateCarWindow.ShowDialog();

                if (updateCarWindow.IsCarUpdated)
                {
                    LoadCars();
                }
            }
        }

        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            CarModel selectedCar = (CarModel)carDataGrid.SelectedItem;
            if (selectedCar != null)
            {
                crudServ.DeleteCar(selectedCar.id);
                LoadCars();
            }
        }

        private void ShowCar(object sender, RoutedEventArgs e)
        {
            CarModel selectedCar = (CarModel)carDataGrid.SelectedItem;
            if (selectedCar != null)
            {
                ShowCarWindow showCarWindow = new ShowCarWindow(crudServ, selectedCar);
                showCarWindow.ShowDialog();
            }
        }

      

        private void IndexUser(object sender, RoutedEventArgs e)
        {
            IndexUserWindow indexUserWindow = new IndexUserWindow(crudServ);
            indexUserWindow.ShowDialog();
        }

        private void IndexEquipment(object sender, RoutedEventArgs e)
        {
            IndexEquipmentWindow indexEquipmentWindow = new IndexEquipmentWindow(crudServ);
            indexEquipmentWindow.ShowDialog();
        }

        private void IndexOrder(object sender, RoutedEventArgs e)
        {
            IndexOrderWindow indexOrderWindow = new IndexOrderWindow(crudServ);
            indexOrderWindow.ShowDialog();
        }

        private void IndexReport(object sender, RoutedEventArgs e)
        {
            IndexReportWindow indexReportWindow = new IndexReportWindow(reportservice, crudServ);
            indexReportWindow.ShowDialog();
        }
    }

}
