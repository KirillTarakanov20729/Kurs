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

namespace KursCarShop.Reports
{
    /// <summary>
    /// Логика взаимодействия для IndexReportWindow.xaml
    /// </summary>
    public partial class IndexReportWindow : Window
    {
        IReportService reportService;
        IDbCrud dbOperations;
        public IndexReportWindow(IReportService reportService, IDbCrud dbOperations)
        {
            InitializeComponent();
            this.reportService = reportService;
            this.dbOperations = dbOperations;
        }

        private void CarsByHorse(object sender, RoutedEventArgs e)
        {
            CarsByHorseWindow carsByHorseWindow = new CarsByHorseWindow(reportService, dbOperations);
            carsByHorseWindow.ShowDialog();
        }

        private void CarsByPrice(object sender, RoutedEventArgs e)
        {
            CarsByPriceWindow carsByPriceWindow = new CarsByPriceWindow(reportService, dbOperations);
            carsByPriceWindow.ShowDialog();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
