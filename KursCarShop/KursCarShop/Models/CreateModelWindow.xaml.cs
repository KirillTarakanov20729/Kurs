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

namespace KursCarShop.Models
{
    /// <summary>
    /// Логика взаимодействия для CreateModelWindow.xaml
    /// </summary>
    public partial class CreateModelWindow : Window
    {
        IDbCrud db;
        public ModelModel NewModel = new ModelModel();
        public bool IsModelCreated { get; private set; } = false;
        public CreateModelWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
        }

        private void CreateModelSave(object sender, RoutedEventArgs e)
        {
            int newModelID = db.GetAllModels().Max(model => model.id) + 1;
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя модели.");
                return; 
            }
            int brandID = ((BrandModel)Brand_id.SelectedItem).id;

            NewModel.id = newModelID;
            NewModel.brand_id = brandID;
            NewModel.name = name;
            db.CreateModel(NewModel);

            IsModelCreated = true;
            Close();
        }

        private void FillComboBox()
        {
            List<BrandModel> brands = db.GetAllBrands();

            Brand_id.ItemsSource = brands;
            Brand_id.DisplayMemberPath = "name";
        }
    }
}
