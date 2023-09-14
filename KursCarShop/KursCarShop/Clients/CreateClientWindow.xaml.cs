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

namespace KursCarShop.Clients
{
    /// <summary>
    /// Логика взаимодействия для CreateClientWindow.xaml
    /// </summary>
    public partial class CreateClientWindow : Window
    {
        IDbCrud db;
        public ClientModel NewClient = new ClientModel();
        public bool IsClientCreated { get; private set; } = false;
        public CreateClientWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
        }

        private void CreateClientSave(object sender, RoutedEventArgs e)
        {
            int newClientID = db.GetAllClients().Max(client => client.id) + 1;
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

            NewClient.id = newClientID;
            NewClient.user_id = userID;
            NewClient.phone = phone;
            NewClient.FIO = FIO;
            db.CreateClient(NewClient);

            IsClientCreated = true;
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
