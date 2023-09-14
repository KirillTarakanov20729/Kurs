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
    /// Логика взаимодействия для UpdateEmployeeWindow.xaml
    /// </summary>
    public partial class UpdateEmployeeWindow : Window
    {
        IDbCrud db;
        public EmployeeModel NewEmployee = new EmployeeModel();
        List<UserModel> users;
        private int employeeIdToUpdate;

        public bool IsEmployeeUpdated { get; private set; } = false;
        public UpdateEmployeeWindow(IDbCrud dbOperations, EmployeeModel employeeToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            LoadEmployeeData(employeeToUpdate);
            employeeIdToUpdate = employeeToUpdate.id;
        }

        private void UpdateEmployeeSave(object sender, RoutedEventArgs e)
        {
            int userID = ((UserModel)User_id.SelectedItem).id;
            if (string.IsNullOrWhiteSpace(FIOTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите телефон");
                return;
            }
            string FIO = FIOTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите телефон");
                return;
            }
            string phone = phoneTextBox.Text.Trim();

            NewEmployee.id = employeeIdToUpdate;
            NewEmployee.user_id = userID;
            NewEmployee.FIO = FIO;
            NewEmployee.phone = phone;


            db.UpdateEmployee(NewEmployee);

            IsEmployeeUpdated = true;
            Close();
        }

        private void FillComboBox()
        {
            users = db.GetAllUsers();

            User_id.ItemsSource = users;
            User_id.DisplayMemberPath = "DisplayString";
        }

        private void LoadEmployeeData(EmployeeModel employee)
        {
            int index = users.FindIndex(user => user.id == employee.user_id);
            User_id.SelectedIndex = index;
            phoneTextBox.Text = employee.phone;
            FIOTextBox.Text = employee.FIO;
        }
    }
}
