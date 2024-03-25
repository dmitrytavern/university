using UniversityServer.Database;

namespace UniversityServer.ViewModels
{
    public class RaportsViewModel : ViewModelBase
    {
        private List<Raports> raports { get; set; } = [];
        public List<Raports> Raports
        {
            get { return raports; }
            set
            {
                raports = value;
                OnPropertyChanged("Raports");
            }
        }

        private string inputRaportTeacherId { get; set; } = "";
        public string InputRaportTeacherId
        {
            get { return inputRaportTeacherId; }
            set
            {
                inputRaportTeacherId = value;
                OnPropertyChanged("InputRaportTeacherId");
            }
        }

        private string inputRaportName { get; set; } = "";
        public string InputRaportName
        {
            get { return inputRaportName; }
            set
            {
                inputRaportName = value;
                OnPropertyChanged("InputRaportName");
            }
        }

        private string inputRaportHours { get; set; } = "";
        public string InputRaportHours
        {
            get { return inputRaportHours; }
            set
            {
                inputRaportHours = value;
                OnPropertyChanged("InputRaportHours");
            }
        }

        private string inputRaportDate { get; set; } = "";
        public string InputRaportDate
        {
            get { return inputRaportDate; }
            set
            {
                inputRaportDate = value;
                OnPropertyChanged("InputRaportDate");
            }
        }
    }
}
