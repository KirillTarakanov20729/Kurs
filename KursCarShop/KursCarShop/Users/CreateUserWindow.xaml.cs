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

namespace KursCarShop.Users
{
    /// <summary>
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        IDbCrud db;
        public UserModel NewUser = new UserModel();
        public bool IsUserCreated { get; private set; } = false;
        public CreateUserWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
        }

        private void CreateUserSave(object sender, RoutedEventArgs e)
        {
            int newUserID = db.GetAllUsers().Max(user => user.id) + 1;
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите email");
                return;
            }
            string email = emailTextBox.Text;
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите пароль");
                return;
            }
            string password = passwordTextBox.Text;
            int typeID = ((TypeModel)Type_id.SelectedItem).id;

            NewUser.id = newUserID;
            NewUser.type_id = typeID;
            NewUser.email = email;
            NewUser.password = password;
            db.CreateUser(NewUser);

            IsUserCreated = true;
            Close();
        }

        private void FillComboBox()
        {
            List<TypeModel> types = db.GetAllTypes();

            Type_id.ItemsSource = types;
            Type_id.DisplayMemberPath = "type";
        }
    }
}
