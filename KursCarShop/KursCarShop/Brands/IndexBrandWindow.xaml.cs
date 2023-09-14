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

namespace KursCarShop.Brands
{
    /// <summary>
    /// Логика взаимодействия для IndexBrandWindow.xaml
    /// </summary>
    public partial class IndexBrandWindow : Window
    {
        IDbCrud crudServ;
        private List<BrandModel> brandList;
        public IndexBrandWindow(IDbCrud crudServ)
        {
            InitializeComponent();
            this.crudServ = crudServ;
            loadBrands();
        }

        private void loadBrands()
        {
            brandList = crudServ.GetAllBrands();
            DisplayBrands(brandList);
        }

        public void DisplayBrands(List<BrandModel> brands)
        {
            brandDataGrid.ItemsSource = brands;
        }

        private void AddBrand(object sender, RoutedEventArgs e)
        {
            CreateBrandWindow createBrandWindow = new CreateBrandWindow(crudServ);
            createBrandWindow.ShowDialog();

            if (createBrandWindow.IsBrandCreated)
            {
                loadBrands();
            }
        }

        private void UpdateBrand(object sender, RoutedEventArgs e)
        {
            BrandModel selectedBrand = (BrandModel)brandDataGrid.SelectedItem;
            if (selectedBrand != null)
            {
                UpdateBrandWindow updateBrandWindow = new UpdateBrandWindow(crudServ, selectedBrand);
                updateBrandWindow.ShowDialog();

                if (updateBrandWindow.IsBrandUpdated)
                {
                    loadBrands();
                }
            }
        }

        private void DeleteBrand(object sender, RoutedEventArgs e)
        {
            BrandModel selectedBrand = (BrandModel)brandDataGrid.SelectedItem;
            if (selectedBrand != null)
            {
                crudServ.DeleteBrand(selectedBrand.id);
                loadBrands();
            }
        }

        private void CloseBrand(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
