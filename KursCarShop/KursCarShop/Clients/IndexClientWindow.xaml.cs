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
using KursCarShop.Users;

namespace KursCarShop.Clients
{
    /// <summary>
    /// Логика взаимодействия для IndexClientWindow.xaml
    /// </summary>
    public partial class IndexClientWindow : Window
    {
        IDbCrud crudServ;
        private List<ClientModel> clientList;
        public IndexClientWindow(IDbCrud crudServ)
        {
            InitializeComponent();
            this.crudServ = crudServ;
            loadClients();
        }

        private void loadClients()
        {
            clientList = crudServ.GetAllClients();
            foreach (var client in clientList)
            {
                client.User = crudServ.GetUser(client.user_id);
            }
            DisplayClients(clientList);
        }

        public void DisplayClients(List<ClientModel> clients)
        {
            clientDataGrid.ItemsSource = clients;
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            CreateClientWindow createClientWindow = new CreateClientWindow(crudServ);
            createClientWindow.ShowDialog();

            if (createClientWindow.IsClientCreated)
            {
                loadClients();
            }
        }

        private void UpdateClient(object sender, RoutedEventArgs e)
        {
            ClientModel selectedClient = (ClientModel)clientDataGrid.SelectedItem;
            if (selectedClient != null)
            {
                UpdateClientWindow updateClientWindow = new UpdateClientWindow(crudServ, selectedClient);
                updateClientWindow.ShowDialog();

                if (updateClientWindow.IsClientUpdated)
                {
                    loadClients();
                }
            }
        }

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            ClientModel selectedClient = (ClientModel)clientDataGrid.SelectedItem;
            if (selectedClient != null)
            {
                crudServ.DeleteClient(selectedClient.id);
                loadClients();
            }
        }

        private void CloseClient(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
