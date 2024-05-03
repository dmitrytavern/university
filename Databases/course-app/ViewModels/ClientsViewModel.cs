using InsuranceCompany.Database;

namespace InsuranceCompany.ViewModels
{
    internal class ClientsViewModel : ViewModelBase
    {
        private List<clients> clients { get; set; } = [];
        public List<clients> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }
    }
}
