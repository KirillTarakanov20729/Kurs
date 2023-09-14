using BLL.Interfaces;
using BLL;
using KursCarShop.Brands;
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
    /// Логика взаимодействия для IndexModelWindow.xaml
    /// </summary>
    public partial class IndexModelWindow : Window
    {
        IDbCrud crudServ;
        private List<ModelModel> modelList;
        public IndexModelWindow(IDbCrud crudServ)
        {
            InitializeComponent();
            this.crudServ = crudServ;
            loadModels();
        }

        private void loadModels()
        {
            modelList = crudServ.GetAllModels();
            foreach (var model in modelList)
            {
                model.Brand = crudServ.GetBrand(model.brand_id);
            }
            DisplayModels(modelList);
        }

        public void DisplayModels(List<ModelModel> models)
        {
            modelDataGrid.ItemsSource = models;
        }

        private void AddModel(object sender, RoutedEventArgs e)
        {
            CreateModelWindow createModelWindow = new CreateModelWindow(crudServ);
            createModelWindow.ShowDialog();

            if (createModelWindow.IsModelCreated)
            {
                loadModels();
            }
        }

        private void UpdateModel(object sender, RoutedEventArgs e)
        {
            ModelModel selectedModel = (ModelModel)modelDataGrid.SelectedItem;
            if (selectedModel != null)
            {
                UpdateModelWindow updateModelWindow = new UpdateModelWindow(crudServ, selectedModel);
                updateModelWindow.ShowDialog();

                if (updateModelWindow.IsModelUpdated)
                {
                    loadModels();
                }
            }
        }

        private void DeleteModel(object sender, RoutedEventArgs e)
        {
            ModelModel selectedModel = (ModelModel)modelDataGrid.SelectedItem;
            if (selectedModel != null)
            {
                crudServ.DeleteModel(selectedModel.id);
                loadModels();
            }
        }

        private void CloseModel(object sender, RoutedEventArgs e)
        {
            Close();
        }

   
    }
}
