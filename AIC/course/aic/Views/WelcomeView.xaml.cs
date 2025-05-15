using System.Windows;
using System.Windows.Controls;

namespace aic.Views
{
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
            ServerField.Text = App.DBServerName;
            DatabaseField.Text = App.DBName;
            UsernameField.Text = App.DBUser;
            PasswordField.Password = App.DBPass;
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string server = ServerField.Text.Trim();
            string database = DatabaseField.Text.Trim();
            string username = UsernameField.Text.Trim();
            string password = PasswordField.Password;

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database))
            {
                MessageBox.Show("Будь ласка, заповніть поля сервера і бази даних.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            App.DBName = database;
            App.DBServerName = server;
            App.DBUser = username;
            App.DBPass = password;

            if (!App.ExistsDatabaseConnection())
            {
                MessageBox.Show("Не вдалося підключитися до бази даних.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MainWindow.MainSidebar.IsEnabled = true;
            MainWindow.MainFrame.Navigate(new DashboardView());
        }
    }
}
