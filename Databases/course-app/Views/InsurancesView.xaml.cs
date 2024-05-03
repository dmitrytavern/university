using InsuranceCompany.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace InsuranceCompany.Views
{
    public partial class InsurancesView : UserControl
    {
        private readonly InsurancesViewModel viewModel = new();

        public InsurancesView()
        {
            InitializeComponent();

            DataContext = viewModel;

            try
            {
                viewModel.Insurances = App.db.insurances.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
