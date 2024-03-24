using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using UniversityClient.Api;

namespace UniversityClient.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectButton.IsEnabled = false;

                App.ApiUrl = AddressInput.Text;

                App.CurrentUser = await LoginApi.Handle(EmailInput.Text, PasswordInput.Text);

                MainWindow.MainFrame.Navigate(new ProfileView());
            }
            catch (HttpRequestException ex)
            {
                StatusTextBlock.Text = "Current status: Error\nResponse: " + ex.Message;
                StatusTextBlock.Visibility = Visibility.Visible;
                ConnectButton.IsEnabled = true;
            }
        }
    }
}
