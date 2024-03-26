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
        public int Id { get; }

        /// <summary>
        /// Gets the teacher's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the teacher's surname.
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Gets the teacher's email.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Initializes a new instance of the TeacherData class with specified parameters.
        /// </summary>
        /// <param name="id">The teacher's ID.</param>
        /// <param name="name">The teacher's name.</param>
        /// <param name="surname">The teacher's surname.</param>
        /// <param name="email">The teacher's email.</param>
        public TeacherData(int id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }
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

