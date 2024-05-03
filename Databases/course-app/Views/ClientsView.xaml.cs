using System.Windows;
using System.Windows.Controls;
using InsuranceCompany.ViewModels;

namespace InsuranceCompany.Views
{
    public partial class ClientsView : UserControl
    {
        private readonly ClientsViewModel viewModel = new();

        public ClientsView()
        {
            InitializeComponent();

            DataContext = viewModel;

            try
            {
                viewModel.Clients = App.db.clients.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
