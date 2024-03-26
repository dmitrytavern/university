using System.Windows;
using UniversityServer.Database;

namespace UniversityServer.ViewModels
{
    public class RatingTeacherData(int number, string name, double hours, Teachers teacher, List<Raports> raports)
    {
        public int number { get; set; } = number;
        public string name { get; } = name;
        public double hours { get; } = hours;
        public Teachers teacher { get; } = teacher;
        public List<Raports> raports { get; } = raports;
    }

    public class RatingViewModel : ViewModelBase
    {
        private List<RatingTeacherData> teachersData { get; set; } = [];
        public List<RatingTeacherData> TeachersData
        {
            get { return teachersData; }
            set
            {
                teachersData = value;
                OnPropertyChanged("TeachersData");
            }
        }

        public void FetchRating()
        {
            List<RatingTeacherData> data = [];
            List<Teachers> teachers = App.db.Teachers.ToList();

            foreach (Teachers teacher in teachers)
            {
                List<Raports> raports = App.db.Raports.Where(p => p.teacher_id == teacher.id && p.date.Year == DateTime.Today.Year).ToList();
             
                double hours = 0;

                foreach(Raports raport in raports)
                {
                    hours += raport.hours;
                }

                hours = Math.Round(hours, 2);

                data.Add(new RatingTeacherData(0, teacher.name + " " + teacher.surname, hours, teacher, raports));
            }

            data.Sort((x, y) => y.hours.CompareTo(x.hours));

            int i = 1;
            foreach (RatingTeacherData teacherData in data)
            {
                teacherData.number = i;
                i++;
            }

            TeachersData = data;
        }
    }
}
