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
using KursCarShop.Brands;

namespace KursCarShop.Equipments
{
    /// <summary>
    /// Логика взаимодействия для IndexEquipmentWindow.xaml
    /// </summary>
    public partial class IndexEquipmentWindow : Window
    {
        IDbCrud crudServ;
        private List<EquipmentModel> equipmentList;
        public IndexEquipmentWindow(IDbCrud crudServ)
        {
            InitializeComponent();
            this.crudServ = crudServ;
            loadEquipments();
        }

        private void loadEquipments()
        {
            equipmentList = crudServ.GetAllEquipments();
            foreach (var equipment in equipmentList)
            {
                equipment.Model = crudServ.GetModel(equipment.model_id);
                equipment.Model.Brand = crudServ.GetBrand(equipment.Model.brand_id);
            }
            DisplayEquipments(equipmentList);
        }

        public void DisplayEquipments(List<EquipmentModel> equipments)
        {
            equipmentDataGrid.ItemsSource = equipments;
        }

        private void AddEquipment(object sender, RoutedEventArgs e)
        {
            CreateEquipmentWindow createEquipmentWindow = new CreateEquipmentWindow(crudServ);
            createEquipmentWindow.ShowDialog();

            if (createEquipmentWindow.IsEquipmentCreated)
            {
                loadEquipments();
            }
        }

        private void UpdateEquipment(object sender, RoutedEventArgs e)
        {
            EquipmentModel selectedEquipment = (EquipmentModel)equipmentDataGrid.SelectedItem;
            if (selectedEquipment != null)
            {
                UpdateEquipmentWindow updateEquipmentWindow = new UpdateEquipmentWindow(crudServ, selectedEquipment);
                updateEquipmentWindow.ShowDialog();

                if (updateEquipmentWindow.IsEquipmentUpdated)
                {
                    loadEquipments();
                }
            }
        }

        private void DeleteEquipment(object sender, RoutedEventArgs e)
        {
            EquipmentModel selectedEquipment = (EquipmentModel)equipmentDataGrid.SelectedItem;
            if (selectedEquipment != null)
            {
                crudServ.DeleteEquipment(selectedEquipment.id);
                loadEquipments();
            }
        }

        private void CloseEquipment(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void IndexBrand(object sender, RoutedEventArgs e)
        {
            IndexBrandWindow indexBrandWindow = new IndexBrandWindow(crudServ);
            indexBrandWindow.ShowDialog();
        }

        private void IndexModel(object sender, RoutedEventArgs e)
        {
            IndexModelWindow indexModelWindow = new IndexModelWindow(crudServ);
            indexModelWindow.ShowDialog();
        }
    }
}
