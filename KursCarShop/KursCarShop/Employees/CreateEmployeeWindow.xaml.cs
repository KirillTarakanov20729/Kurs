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
using System.Net;

namespace KursCarShop.Employees
{
    /// <summary>
    /// Логика взаимодействия для CreateEmployeeWindow.xaml
    /// </summary>
    public partial class CreateEmployeeWindow : Window
    {
        IDbCrud db;
        public EmployeeModel NewEmployee = new EmployeeModel();
        public bool IsEmployeeCreated { get; private set; } = false;
        public CreateEmployeeWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
        }

        private void CreateEmployeeSave(object sender, RoutedEventArgs e)
        {
            int newEmployeeID = db.GetAllEmployees().Max(client => client.id) + 1;
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите телефон");
                return;
            }
            string phone = phoneTextBox.Text;
            if (string.IsNullOrWhiteSpace(FIOTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите телефон");
                return;
            }
            string FIO = FIOTextBox.Text;
            int userID = ((UserModel)User_id.SelectedItem).id;

            NewEmployee.id = newEmployeeID;
            NewEmployee.user_id = userID;
            NewEmployee.phone = phone;
            NewEmployee.FIO = FIO;
            db.CreateEmployee(NewEmployee);

            IsEmployeeCreated = true;
            Close();
        }
        private void FillComboBox()
        {
            List<UserModel> users = db.GetAllUsers();

            User_id.ItemsSource = users;
            User_id.DisplayMemberPath = "DisplayString";
        }
    }
}
