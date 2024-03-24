using System.Windows.Controls;

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
    }
}
