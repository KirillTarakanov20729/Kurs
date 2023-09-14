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
    /// Логика взаимодействия для CarsByHorseWindow.xaml
    /// </summary>
    public partial class CarsByHorseWindow : Window
    {
        IReportService reportService;
        IDbCrud dbOperations;
        public CarsByHorseWindow(IReportService reportService, IDbCrud dbOperations)
        {
            InitializeComponent();
            this.reportService = reportService;
            this.dbOperations = dbOperations;
            FillComboBox();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var cars = reportService.CarsByHorse((int)Equipment_id.SelectedItem);
            foreach (var car in cars)
            {
                
            }
            CarsByHorseDataGrid.ItemsSource = cars;
        }

        private void FillComboBox()
        {
            List<EquipmentModel> equips = dbOperations.GetAllEquipments();

     
            var uniqueHorsepowers = equips.Select(equip => equip.horsepower).Distinct().ToList();

       
            Equipment_id.ItemsSource = uniqueHorsepowers;
        }

    }
}
