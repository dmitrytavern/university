using System.Windows;
using InsuranceCompany.Views;

namespace InsuranceCompany
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavigateToEvents(object sender, RoutedEventArgs e)
        {
            navframe.Navigate(new EventsView());
        }

        private void NavigateToClients(object sender, RoutedEventArgs e)
        {
            navframe.Navigate(new ClientsView());
        }

        private void NavigateToInsurances(object sender, RoutedEventArgs e)
        {
            navframe.Navigate(new InsurancesView());
        }

        private void NavigateToAdmins(object sender, RoutedEventArgs e)
        {
            navframe.Navigate(new AdminsView());
        }
    }
}