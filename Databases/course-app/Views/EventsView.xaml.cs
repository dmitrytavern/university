using InsuranceCompany.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace InsuranceCompany.Views
{
    public partial class EventsView : UserControl
    {
        private readonly EventsViewModel viewModel = new();

        public EventsView()
        {
            InitializeComponent();

            DataContext = viewModel;

            try
            {
                viewModel.Events = App.db.events.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
