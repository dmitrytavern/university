using InsuranceCompany.Database;

namespace InsuranceCompany.ViewModels
{
    internal class EventsViewModel : ViewModelBase
    {
        private List<events> events { get; set; } = [];
        public List<events> Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }
    }
}
