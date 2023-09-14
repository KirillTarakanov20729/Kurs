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
    /// Логика взаимодействия для UpdateBrandWindow.xaml
    /// </summary>
    public partial class UpdateBrandWindow : Window
    {
        IDbCrud db;
        public BrandModel NewBrand = new BrandModel();
        private int brandIdToUpdate;

        public bool IsBrandUpdated { get; private set; } = false;
        public UpdateBrandWindow(IDbCrud dbOperations, BrandModel brandToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            LoadBrandData(brandToUpdate);
            brandIdToUpdate = brandToUpdate.id;
        }

        private void LoadBrandData(BrandModel brand)
        {
            nameTextBox.Text = brand.name;
        }

        private void UpdateBrandSave(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя бренда.");
                return; 
            }


            NewBrand.id = brandIdToUpdate;
            NewBrand.name = name;

            db.UpdateBrand(NewBrand);

            IsBrandUpdated = true;
            Close();
        }
    }
}
