using InsuranceCompany.Database;

namespace InsuranceCompany.ViewModels
{
    internal class AdminsViewModel : ViewModelBase
    {
        private List<admins> admins { get; set; } = [];
        public List<admins> Admins
        {
            get { return admins; }
            set
            {
                admins = value;
                OnPropertyChanged("Admins");
            }
        }
    }
}
