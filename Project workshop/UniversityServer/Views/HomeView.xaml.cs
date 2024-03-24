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
