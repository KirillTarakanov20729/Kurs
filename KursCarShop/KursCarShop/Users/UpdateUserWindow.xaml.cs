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
    /// Логика взаимодействия для UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        IDbCrud db;
        public UserModel NewUser = new UserModel();
        List<TypeModel> types;
        private int userIdToUpdate;

        public bool IsUserUpdated { get; private set; } = false;
        public UpdateUserWindow(IDbCrud dbOperations, UserModel userToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            LoadUserData(userToUpdate);
            userIdToUpdate = userToUpdate.id;
        }

        private void UpdateUserSave(object sender, RoutedEventArgs e)
        {
            int typeID = ((TypeModel)Type_id.SelectedItem).id;
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите email");
                return;
            }
            string email = emailTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите пароль");
                return;
            }
            string password = passwordTextBox.Text.Trim();

            NewUser.id = userIdToUpdate;
            NewUser.type_id = typeID;
            NewUser.email = email;
            NewUser.password = password;


            db.UpdateUser(NewUser);

            IsUserUpdated = true;
            Close();
        }
        private void FillComboBox()
        {
            types = db.GetAllTypes();

            Type_id.ItemsSource = types;
            Type_id.DisplayMemberPath = "type";
        }

        private void LoadUserData(UserModel user)
        {
            int index = types.FindIndex(type => type.id == user.type_id);
            Type_id.SelectedIndex = index;
            emailTextBox.Text = user.email;
            passwordTextBox.Text = user.password;
        }
    }
}
