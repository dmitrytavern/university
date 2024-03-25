using System.Windows;
using System.Windows.Controls;
using UniversityClient.Api;

namespace UniversityClient.Views
{
    public partial class CreateRaportView : UserControl
    {
        public CreateRaportView()
        {
            InitializeComponent();
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckFormValidation()) return;

                UniversityServer.HttpMessage message = await CreateRaportApi.Handle(
                    RaportNameInput.Text,
                    RaportHoursInput.Text,
                    RaportDateInput.Text
                );

                ClearForm();

                StatusTextBlock.Visibility = Visibility.Visible;
                StatusTextBlock.Text = "Success: " + message.message;
            }
            catch(Exception ex)
            {
                StatusTextBlock.Visibility = Visibility.Visible;
                StatusTextBlock.Text = "Error: " + ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new ProfileView());
        }

        private bool CheckFormValidation()
        {
            if (string.IsNullOrWhiteSpace(RaportNameInput.Text) ||
                string.IsNullOrWhiteSpace(RaportHoursInput.Text) ||
                string.IsNullOrWhiteSpace(RaportDateInput.Text))
            {
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            RaportNameInput.Text = "";
            RaportHoursInput.Text = "";
            RaportDateInput.Text = "";
        }
    }
}
