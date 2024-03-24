using System.Windows;
using UniversityServer.Database;

namespace UniversityClient
{
    public partial class App : Application
    {
        public static string ApiUrl { get; set; } = "";
        public static Teachers? CurrentUser { get; set; }
    }
}
