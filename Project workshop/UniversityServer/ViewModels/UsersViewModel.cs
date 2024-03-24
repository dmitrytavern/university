using UniversityServer.Database;

namespace UniversityServer.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        private List<Teachers> teachers { get; set; } = [];
        public List<Teachers> Teachers
        {
            get { return teachers; }
            set
            {
                teachers = value;
                OnPropertyChanged("Teachers");
            }
        }

        private string inputTeacherName { get; set; } = "";
        public string InputTeacherName
        {
            get { return inputTeacherName; }
            set
            {
                inputTeacherName = value;
                OnPropertyChanged("InputTeacherName");
            }
        }

        private string inputTeacherSurname { get; set; } = "";
        public string InputTeacherSurname
        {
            get { return inputTeacherSurname; }
            set
            {
                inputTeacherSurname = value;
                OnPropertyChanged("InputTeacherSurname");
            }
        }

        private string inputTeacherEmail { get; set; } = "";
        public string InputTeacherEmail
        {
            get { return inputTeacherEmail; }
            set
            {
                inputTeacherEmail = value;
                OnPropertyChanged("InputTeacherEmail");
            }
        }

        private string inputTeacherPassword { get; set; } = "";
        public string InputTeacherPassword
        {
            get { return inputTeacherPassword; }
            set
            {
                inputTeacherPassword = value;
                OnPropertyChanged("InputTeacherPassword");
            }
        }
    }
}
