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

namespace KursCarShop.Equipments
{
    /// <summary>
    /// Логика взаимодействия для CreateEquipmentWindow.xaml
    /// </summary>
    public partial class CreateEquipmentWindow : Window
    {
        IDbCrud db;
        public EquipmentModel NewEquipment = new EquipmentModel();
        public bool IsEquipmentCreated { get; private set; } = false;
        public CreateEquipmentWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBoxModels();
        }

        private void FillComboBoxModels()
        {
            List<ModelModel> models = db.GetAllModels();
            foreach (ModelModel model in models) 
            {
                model.Brand = db.GetBrand(model.brand_id);
            }
            Model_id.ItemsSource = models;
            Model_id.DisplayMemberPath = "DisplayString";
        }

        private void CreateEquipmentSave(object sender, RoutedEventArgs e)
        {
            int newEquipmentID = db.GetAllEquipments().Max(equipment => equipment.id) + 1;
            if (string.IsNullOrWhiteSpace(capacityTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите объем");
                return;
            }
            double capacity = double.Parse(capacityTextBox.Text);
            if (string.IsNullOrWhiteSpace(horsepowerTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите Л.С.");
                return;
            }
            int horsepower = int.Parse(horsepowerTextBox.Text);
            int modelID = ((ModelModel)Model_id.SelectedItem).id;
            string selectedTransmission = ((ComboBoxItem)Transmission.SelectedItem).Content.ToString();

            NewEquipment.id = newEquipmentID;
            NewEquipment.model_id = modelID;
            NewEquipment.engine_capacity = capacity;
            NewEquipment.horsepower = horsepower;
            NewEquipment.transmission = selectedTransmission;
            db.CreateEquipment(NewEquipment);

            IsEquipmentCreated = true;
            Close();
        }
    }
}
