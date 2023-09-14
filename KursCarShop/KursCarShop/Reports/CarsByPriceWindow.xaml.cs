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

namespace KursCarShop.Reports
{
    /// <summary>
    /// Логика взаимодействия для CarsByPriceWindow.xaml
    /// </summary>
    public partial class CarsByPriceWindow : Window
    {
        IReportService reportService;
        IDbCrud dbOperations;
        public CarsByPriceWindow(IReportService reportService, IDbCrud dbOperations)
        {
            InitializeComponent();
            this.reportService = reportService;
            this.dbOperations = dbOperations;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var cars = reportService.CarsByPrices(int.Parse(minTextBox.Text), int.Parse(maxTextBox.Text));
            CarsByPriceDataGrid.ItemsSource = cars;
        }
    }
}
