using InsuranceCompany.Database;

namespace InsuranceCompany.ViewModels
{
    internal class InsurancesViewModel : ViewModelBase
    {
        private List<insurances> insurances { get; set; } = [];
        public List<insurances> Insurances
        {
            get { return insurances; }
            set
            {
                insurances = value;
                OnPropertyChanged("Insurances");
            }
        }
    }
}
