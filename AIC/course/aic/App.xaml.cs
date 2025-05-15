using Microsoft.Data.SqlClient;
using System.Windows;

namespace aic
{
    public partial class App : Application
    {
        public static string DBName { get; set; } = "aic2";
        public static string DBServerName { get; set; } = "DESKTOP-4EQTI1O";
        public static string? DBUser { get; set; } = null;
        public static string? DBPass { get; set; } = null;

        public static int CurrentYear { get; set; } = 2024;
        public static int CurrentSemester { get; set; } = 2;

        public static bool ExistsDatabaseConnection()
        {
            try
            {
                using (SqlConnection connection = new(GetDatabaseConnectionString()))
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception _)
            {
                return false;
            }
        }

        public static string GetDatabaseConnectionString()
        {
            string connectionString = $"Server={DBServerName}; Database={DBName};";

            if (!string.IsNullOrEmpty(DBUser) && !string.IsNullOrEmpty(DBPass))
            {
                connectionString += $"User Id={DBUser}; Password={DBPass};";
            }
            else
            {
                connectionString += "Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
            }

            return connectionString;
        }
    }
}
