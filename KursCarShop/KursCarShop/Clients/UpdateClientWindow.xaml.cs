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
    /// Логика взаимодействия для UpdateClientWindow.xaml
    /// </summary>
    public partial class UpdateClientWindow : Window
    {
        IDbCrud db;
        public ClientModel NewClient = new ClientModel();
        List<UserModel> users;
        private int clientIdToUpdate;

        public bool IsClientUpdated { get; private set; } = false;
        public UpdateClientWindow(IDbCrud dbOperations, ClientModel clientToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            LoadClientData(clientToUpdate);
            clientIdToUpdate = clientToUpdate.id;
        }

        private void FillComboBox()
        {
            users = db.GetAllUsers();

            User_id.ItemsSource = users;
            User_id.DisplayMemberPath = "DisplayString";
        }

        private void LoadClientData(ClientModel client)
        {
            int index = users.FindIndex(user => user.id == client.user_id);
            User_id.SelectedIndex = index;
            phoneTextBox.Text = client.phone;
            FIOTextBox.Text = client.FIO;
        }

        private void UpdateClientSave(object sender, RoutedEventArgs e)
        {
            int userID = ((UserModel)User_id.SelectedItem).id;
            if (string.IsNullOrWhiteSpace(FIOTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите ФИО"); 
                return;
            }
            string FIO = FIOTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите телефон");
                return;
            }
            string phone = phoneTextBox.Text.Trim();

            NewClient.id = clientIdToUpdate;
            NewClient.user_id = userID;
            NewClient.FIO = FIO;
            NewClient.phone = phone;


            db.UpdateClient(NewClient);

            IsClientUpdated = true;
            Close();
        }
    }
}
