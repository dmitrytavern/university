using System.Windows;
using System.Windows.Controls;
using UniversityClient.Api;

namespace UniversityClient.Views
{
    /// <summary>
    /// Represents the view for creating a report.
    /// </summary>
    public partial class CreateRaportView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CreateRaportView class.
        /// </summary>
        public CreateRaportView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the create button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
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
            catch (Exception ex)
            {
                StatusTextBlock.Visibility = Visibility.Visible;
                StatusTextBlock.Text = "Error: " + ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the back button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new ProfileView());
        }

        /// <summary>
        /// Checks the validation of the form.
        /// </summary>
        /// <returns>True if the form is valid, otherwise false.</returns>
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

        /// <summary>
        /// Clears the form fields.
        /// </summary>
        private void ClearForm()
        {
            RaportNameInput.Text = "";
            RaportHoursInput.Text = "";
            RaportDateInput.Text = "";
        }
    }
}