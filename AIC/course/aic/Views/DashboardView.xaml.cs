using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace aic.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            YearField.Text = App.CurrentYear.ToString();
            SemesterComboBox.SelectedIndex = App.CurrentSemester - 1;
            LoadStatistics();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentYear = Convert.ToInt32(YearField.Text);
            App.CurrentSemester = SemesterComboBox.SelectedIndex + 1;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            using (var conn = new SqlConnection(App.GetDatabaseConnectionString()))
            {
                conn.Open();
                FacultiesCountText.Text = "Факультетів: " + Count("faculties", conn);
                DepartmentsCountText.Text = "Кафедр: " + Count("departments", conn);
                SpecialtiesCountText.Text = "Спеціальностей: " + Count("specialties", conn);
                SubjectsCountText.Text = "Предметів: " + Count("subjects", conn);
                TeachersCountText.Text = "Викладачів: " + Count("teachers", conn);
                GroupsCountText.Text = "Активних груп: " + CountActiveGroups(conn);
                StudentsCountText.Text = "Активних студентів: " + CountActiveStudents(conn);
                conn.Close();
            }
        }

        private int Count(string tableName, SqlConnection conn)
        {
            using (var cmd = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }

        private int CountActiveGroups(SqlConnection conn)
        {
            var cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM groups 
            WHERE @CurrentYear - created_year >= 0 AND @CurrentYear - created_year < 4", conn);
            cmd.Parameters.AddWithValue("@CurrentYear", App.CurrentYear);
            return (int)cmd.ExecuteScalar();
        }

        private int CountActiveStudents(SqlConnection conn)
        {
            var cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM students 
            WHERE group_id IN (
                SELECT id FROM groups 
                WHERE @CurrentYear - created_year >= 0 AND @CurrentYear - created_year < 4
            )", conn);
            cmd.Parameters.AddWithValue("@CurrentYear", App.CurrentYear);
            return (int)cmd.ExecuteScalar();
        }
    }
}
