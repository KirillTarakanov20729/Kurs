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
using KursCarShop.Models;
using KursCarShop.Clients;
using KursCarShop.Employees;

namespace KursCarShop.Users
{
    /// <summary>
    /// Логика взаимодействия для IndexUserWindow.xaml
    /// </summary>
    public partial class IndexUserWindow : Window
    {
        IDbCrud crudServ;
        private List<UserModel> userList;
        public IndexUserWindow(IDbCrud crudServ)
        {
            InitializeComponent();
            this.crudServ = crudServ;
            loadUsers();
        }

        private void loadUsers() 
        {
            userList = crudServ.GetAllUsers();
            foreach (var user in userList)
            {
                user.Type = crudServ.GetType(user.type_id);
            }
            DisplayUsers(userList);
        }

        public void DisplayUsers(List<UserModel> users)
        {
            userDataGrid.ItemsSource = users;
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow(crudServ);
            createUserWindow.ShowDialog();

            if (createUserWindow.IsUserCreated)
            {
                loadUsers();
            }
        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {
            UserModel selectedUser = (UserModel)userDataGrid.SelectedItem;
            if (selectedUser != null)
            {
                UpdateUserWindow updateUserWindow = new UpdateUserWindow(crudServ, selectedUser);
                updateUserWindow.ShowDialog();

                if (updateUserWindow.IsUserUpdated)
                {
                    loadUsers();
                }
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            UserModel selectedUser= (UserModel)userDataGrid.SelectedItem;
            if (selectedUser != null)
            {
                crudServ.DeleteUser(selectedUser.id);
                loadUsers();
            }
        }

        private void IndexClient(object sender, RoutedEventArgs e)
        {
            IndexClientWindow indexClientWindow = new IndexClientWindow(crudServ);
            indexClientWindow.ShowDialog();
        }

        private void IndexEmployee(object sender, RoutedEventArgs e)
        {
            IndexEmployeeWindow indexEmployeeWindow = new IndexEmployeeWindow(crudServ);
            indexEmployeeWindow.ShowDialog();
        }

        private void CloseUser(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
