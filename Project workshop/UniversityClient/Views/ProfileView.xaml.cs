using System.Windows.Controls;
using UniversityServer.Views;

namespace UniversityClient.Views
{
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
            WelcomeTextBlock.Text = "Welcome, " + App.CurrentUser?.name + " " + App.CurrentUser?.surname;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.CurrentUser = null;
            MainWindow.MainFrame.Navigate(new LoginView());
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new CreateRaportView());
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new RatingView());
        }
    }
}
