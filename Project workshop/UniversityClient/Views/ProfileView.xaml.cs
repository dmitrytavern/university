using System.Windows.Controls;

namespace UniversityClient.Views
{
    /// <summary>
    /// Represents the profile view.
    /// </summary>
    public partial class ProfileView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ProfileView class.
        /// </summary>
        public ProfileView()
        {
            InitializeComponent();
            WelcomeTextBlock.Text = "Welcome, " + App.CurrentUser?.name + " " + App.CurrentUser?.surname;
        }

        /// <summary>
        /// Handles the Click event of the logout button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.CurrentUser = null;
            MainWindow.MainFrame.Navigate(new LoginView());
        }

        /// <summary>
        /// Handles the Click event of the create report button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new CreateRaportView());
        }

        /// <summary>
        /// Handles the Click event of the view rating button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new RatingView());
        }
    }
}
