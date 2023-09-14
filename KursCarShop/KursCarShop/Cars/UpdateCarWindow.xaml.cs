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

namespace KursCarShop
{
    /// <summary>
    /// Логика взаимодействия для UpdateCarWindow.xaml
    /// </summary>
    public partial class UpdateCarWindow : Window
    {
        IDbCrud db;
        public CarModel NewCar = new CarModel();
        List<EquipmentModel> equipments;
        private int carIdToUpdate;

        public bool IsCarUpdated { get; private set; } = false;
        public UpdateCarWindow(IDbCrud dbOperations, CarModel carToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            LoadCarData(carToUpdate);
            carIdToUpdate = carToUpdate.id;
        }

        private void FillComboBox()
        {
            equipments = db.GetAllEquipments();
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

        private void LoadCarData(CarModel car)
        {
            int index = equipments.FindIndex(equipment => equipment.id == car.equipment_id);
            Equipment_ID.SelectedIndex = index;
            priceTextBox.Text = car.price.ToString();
            colourTextBox.Text = car.colour;
            availabilityCheckBox.IsChecked = car.availability;
        }

        private void UpdateCarSave(object sender, RoutedEventArgs e)
        {
        
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

            NewCar.id = carIdToUpdate;
            NewCar.equipment_id = equipmentID;
            NewCar.price = price;
            NewCar.colour = colour;
            NewCar.availability = availability;

            db.UpdateCar(NewCar); 

            IsCarUpdated = true;
            Close();
        }
    }
}
