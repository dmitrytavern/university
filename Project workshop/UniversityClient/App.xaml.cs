using System.Windows;

namespace UniversityClient
{
    /// <summary>
    /// Represents teacher data.
    /// </summary>
    public class TeacherData
    {
        /// <summary>
        /// Gets the teacher's ID.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets the teacher's name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets the teacher's surname.
        /// </summary>
        public string surname { get; set; }

        /// <summary>
        /// Gets the teacher's email.
        /// </summary>
        public string email { get; set; }
    }

    /// <summary>
    /// Represents the application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        public static string ApiUrl { get; set; } = "";

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public static TeacherData? CurrentUser { get; set; }
    }
}

