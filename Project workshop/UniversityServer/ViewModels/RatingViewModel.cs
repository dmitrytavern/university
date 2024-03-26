using System.Windows;
using UniversityServer.Database;

namespace UniversityServer.ViewModels
{
    public class RatingRaportData(double hours, DateTime date)
    {
        public double hours { get; } = hours;
        public DateTime date { get; } = date;
    }

    public class RatingTeacherData(int number, string name, double hours, List<RatingRaportData> raports)
    {
        public int number { get; set; } = number;
        public string name { get; } = name;
        public double hours { get; } = hours;
        public List<RatingRaportData> raports { get; } = raports;
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
                List<RatingRaportData> raportsData = [];
                List<Raports> raports = App.db.Raports.Where(p => p.teacher_id == teacher.id && p.date.Year == DateTime.Today.Year).ToList();
             
                double hours = 0;

                foreach(Raports raport in raports)
                {
                    raportsData.Add(new RatingRaportData(raport.hours, raport.date));
                    hours += raport.hours;
                }

                hours = Math.Round(hours, 2);

                data.Add(new RatingTeacherData(0, teacher.name + " " + teacher.surname, hours, raportsData));
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
