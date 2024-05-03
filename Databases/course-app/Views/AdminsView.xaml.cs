using InsuranceCompany.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace InsuranceCompany.Views
{
    public partial class AdminsView : UserControl
    {
        private readonly AdminsViewModel viewModel = new();

        public AdminsView()
        {
            InitializeComponent();

            DataContext = viewModel;

            try
            {
                viewModel.Admins = App.db.admins.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
