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
using KursCarShop.Clients;

namespace KursCarShop.Employees
{
    /// <summary>
    /// Логика взаимодействия для IndexEmployeeWindow.xaml
    /// </summary>
    public partial class IndexEmployeeWindow : Window
    {
        IDbCrud crudServ;
        private List<EmployeeModel> employeeList;
        public IndexEmployeeWindow(IDbCrud crudServ)
        {
            InitializeComponent();
            this.crudServ = crudServ;
            loadEmployees();
        }

        private void loadEmployees()
        {
            employeeList = crudServ.GetAllEmployees();
            foreach (var employee in employeeList)
            {
                employee.User = crudServ.GetUser(employee.user_id);
            }
            DisplayEmployees(employeeList);
        }

        public void DisplayEmployees(List<EmployeeModel> employees)
        {
            employeeDataGrid.ItemsSource = employees;
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            CreateEmployeeWindow createEmployeeWindow = new CreateEmployeeWindow(crudServ);
            createEmployeeWindow.ShowDialog();

            if (createEmployeeWindow.IsEmployeeCreated)
            {
                loadEmployees();
            }
        }

        private void UpdateEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeModel selectedEmployee = (EmployeeModel)employeeDataGrid.SelectedItem;
            if (selectedEmployee != null)
            {
                UpdateEmployeeWindow updateEmployeeWindow = new UpdateEmployeeWindow(crudServ, selectedEmployee);
                updateEmployeeWindow.ShowDialog();

                if (updateEmployeeWindow.IsEmployeeUpdated)
                {
                    loadEmployees();
                }
            }
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeModel selectedEmployee = (EmployeeModel)employeeDataGrid.SelectedItem;
            if (selectedEmployee != null)
            {
                crudServ.DeleteEmployee(selectedEmployee.id);
                loadEmployees();
            }
        }

        private void CloseEmployee(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
