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

namespace KursCarShop
{
    public partial class ShowCarWindow : Window
    {
        IDbCrud db;

        public CarModel CarToShow { get; set; } 

        public ShowCarWindow(IDbCrud dbOperations, CarModel carToShow)
        {
            InitializeComponent();
            db = dbOperations;

            CarToShow = carToShow; 
            DataContext = this; 
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

