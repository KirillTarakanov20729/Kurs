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
    /// Логика взаимодействия для UpdateEquipmentWindow.xaml
    /// </summary>
    public partial class UpdateEquipmentWindow : Window
    {
        IDbCrud db;
        public EquipmentModel NewEquipment = new EquipmentModel();
        List<ModelModel> models;
        private int equipmentIdToUpdate;

        public bool IsEquipmentUpdated { get; private set; } = false;
        public UpdateEquipmentWindow(IDbCrud dbOperations, EquipmentModel equipmentToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            LoadEquipmentData(equipmentToUpdate);
            equipmentIdToUpdate = equipmentToUpdate.id;
        }

        private void FillComboBox()
        {
            models = db.GetAllModels();
            foreach (ModelModel model in models)
            {
                model.Brand = db.GetBrand(model.brand_id);
            }
            Model_id.ItemsSource = models;
            Model_id.DisplayMemberPath = "DisplayString";
        }

        private void LoadEquipmentData(EquipmentModel equipment)
        {
            int index = models.FindIndex(model => model.id == equipment.model_id);
            Model_id.SelectedIndex = index;
            capacityTextBox.Text = equipment.engine_capacity.ToString();
            horsepowerTextBox.Text = equipment.horsepower.ToString();
        }

        private void UpdateEquipmentSave(object sender, RoutedEventArgs e)
        {
            int modelID = ((ModelModel)Model_id.SelectedItem).id;
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
            string selectedTransmission = ((ComboBoxItem)Transmission.SelectedItem).Content.ToString();


            NewEquipment.id = equipmentIdToUpdate;
            NewEquipment.model_id = modelID;
            NewEquipment.horsepower = horsepower;
            NewEquipment.engine_capacity = capacity;
            NewEquipment.transmission = selectedTransmission;


            db.UpdateEquipment(NewEquipment);

            IsEquipmentUpdated = true;
            Close();
        }
    }
}
