using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using UniversityClient.Api;

namespace UniversityClient.Views
{
    /// <summary>
    /// Represents the login view.
    /// </summary>
    public partial class LoginView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the LoginView class.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the connect button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
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

