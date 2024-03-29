using System.Windows;
using System.Windows.Controls;

namespace UniversityServer.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            ServerPortInput.Text = App.ServerPort;
            ServerDBNameInput.Text = App.DBName;
            ServerDBSourceInput.Text = App.DBSource;

            ServerDBNameInput.IsEnabled = App.db == null;
            ServerDBSourceInput.IsEnabled = App.db == null;
            ConnectButton.IsEnabled = App.db == null;

            if (App.ServerActive)
            {
                SetOnlineState();
            }
            else
            {
                SetOfflineState();
            }
        }

        private void ServerPortInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.ServerPort = ServerPortInput.Text;
        }

        private void ServerDBNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.DBName = ServerDBNameInput.Text;
        }

        private void ServerDBSourceInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.DBSource = ServerDBSourceInput.Text;
        }

        private void ConnectButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                App.ConnectDatabase();
                ServerDBNameInput.IsEnabled = false;
                ServerDBSourceInput.IsEnabled = false;
                ConnectButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetOnlineState();
                App.StartServer();
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetOfflineState();
                App.StopServer();
            } catch(Exception ex)
            {
                SetError(ex);
            }
        }

        private void SetError(Exception? ex)
        {
            ServerStatusText.Text = "Server status: Error.\nError message: " + ex?.Message;
        }

        private void SetOnlineState()
        {
            ServerStatusText.Text = "Server status: Online";
            StopButton.IsEnabled = true;
            StartButton.IsEnabled = false;
            ServerPortInput.IsEnabled = false;
        }

        private void SetOfflineState()
        {
            ServerStatusText.Text = "Server status: Offline";
            StopButton.IsEnabled = false;
            StartButton.IsEnabled = true;
            ServerPortInput.IsEnabled = true;
        }
    }
}
