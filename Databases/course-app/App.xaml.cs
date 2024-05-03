using System.Windows;
using InsuranceCompany.Database;

namespace InsuranceCompany
{
    public partial class App : Application
    {
        public static readonly DataClassesDataContext db;
        public static readonly string DBName = "insurance_company";
        public static readonly string DBSource = "DESKTOP-4EQTI1O";

        static App()
        {
            db = new DataClassesDataContext(@"Data Source=" + DBSource + ";Initial Catalog=" + DBName + ";Integrated Security=True");

            if (db.DatabaseExists() == false)
            {
                db.CreateDatabase();
            }
        }
    }
}
