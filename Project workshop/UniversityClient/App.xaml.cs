using System.Data.Linq.SqlClient;
using System.Windows;

namespace UniversityClient
{
    public class TeacherData(int id, string name, string surname, string email)
    {
        public int id { get; } = id;
        public string name { get; } = name;
        public string surname { get; } = surname;
        public string email { get; } = email;
    }

    public partial class App : Application
    {
        public static string ApiUrl { get; set; } = "";
        public static TeacherData? CurrentUser { get; set; }
    }
}
