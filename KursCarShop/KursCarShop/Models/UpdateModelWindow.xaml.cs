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

namespace KursCarShop.Models
{
    /// <summary>
    /// Логика взаимодействия для UpdateModelWindow.xaml
    /// </summary>
    public partial class UpdateModelWindow : Window
    {
        IDbCrud db;
        public ModelModel NewModel = new ModelModel();
        List<BrandModel> brands;
        private int modelIdToUpdate;

        public bool IsModelUpdated { get; private set; } = false;
        public UpdateModelWindow(IDbCrud dbOperations, ModelModel modelToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            LoadModelData(modelToUpdate);
            modelIdToUpdate = modelToUpdate.id;
        }

        private void UpdateModelSave(object sender, RoutedEventArgs e)
        {
            int brandID = ((BrandModel)Brand_id.SelectedItem).id;
            string name = nameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя модели.");
                return;
            }

            NewModel.id = modelIdToUpdate;
            NewModel.brand_id = brandID;
            NewModel.name = name;
         

            db.UpdateModel(NewModel);

            IsModelUpdated = true;
            Close();
        }

        private void FillComboBox()
        {
            brands = db.GetAllBrands();

            Brand_id.ItemsSource = brands;
            Brand_id.DisplayMemberPath = "name";
        }

        private void LoadModelData(ModelModel model)
        {
            int index = brands.FindIndex(brand => brand.id == model.brand_id);
            Brand_id.SelectedIndex = index;
            nameTextBox.Text = model.name;
        }
    }
}
