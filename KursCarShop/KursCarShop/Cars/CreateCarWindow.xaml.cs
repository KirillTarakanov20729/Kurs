using BLL;
using BLL.Interfaces;
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
using System.Xml.Linq;

namespace KursCarShop
{
    /// <summary>
    /// Логика взаимодействия для CreateCarWindow.xaml
    /// </summary>
    public partial class CreateCarWindow : Window
    {
        IDbCrud db;
        IAddCarService service;
        public CarModel NewCar = new CarModel();
        public bool IsCarCreated { get; private set; } = false;
        public CreateCarWindow(IDbCrud dbOperations, IAddCarService orderService)
        {
            InitializeComponent();
            db = dbOperations;
            service = orderService;
            FillComboBox();
        }

        private void FillComboBox()
        {
            List<EquipmentModel> equipments = db.GetAllEquipments();
            List<ModelModel> models = db.GetAllModels();
            List<BrandModel> brands = db.GetAllBrands();

            foreach (EquipmentModel equip in equipments)
            {
                equip.Model = models.FirstOrDefault(model => model.id == equip.model_id);
                equip.Model.Brand = brands.FirstOrDefault(brand => brand.id == equip.Model.brand_id);
            }

            Equipment_ID.ItemsSource = equipments;
            Equipment_ID.DisplayMemberPath = "DisplayString";
        }




        private void CreateCarSave(object sender, RoutedEventArgs e)
        {
            int newCarID = db.GetAllCars().Max(car => car.id) + 1;
            int equipmentID = ((EquipmentModel)Equipment_ID.SelectedItem).id;
            if (string.IsNullOrWhiteSpace(priceTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите цену");
                return;
            }
            int price = int.Parse(priceTextBox.Text);
            if (string.IsNullOrWhiteSpace(colourTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите цвет");
                return;
            }
            string colour = colourTextBox.Text;
            bool availability = availabilityCheckBox.IsChecked ?? false;

            NewCar.id = newCarID;
            NewCar.equipment_id = equipmentID;
            NewCar.price = price;
            NewCar.availability = availability;
            NewCar.colour = colour;
            service.AddCar(NewCar);

            IsCarCreated = true;
            Close(); 
        }
    }
    
}
