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

namespace KursCarShop.Brands
{
    /// <summary>
    /// Логика взаимодействия для CreateBrandWindow.xaml
    /// </summary>
    public partial class CreateBrandWindow : Window
    {
        IDbCrud db;
        public BrandModel NewBrand = new BrandModel();
        public bool IsBrandCreated { get; private set; } = false;
        public CreateBrandWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;
        }

        private void CreateBrandSave(object sender, RoutedEventArgs e)
        {
            int newBrandID = db.GetAllBrands().Max(brand => brand.id) + 1;
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя бренда.");
                return; 
            }

            NewBrand.id = newBrandID;
            NewBrand.name = name;
            db.CreateBrand(NewBrand);

            IsBrandCreated = true;
            Close();
        }
    }
}
