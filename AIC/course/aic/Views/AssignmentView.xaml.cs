using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aic.Views
{
    /// <summary>
    /// Interaction logic for AssignmentView.xaml
    /// </summary>
    public partial class AssignmentView : UserControl
    {
        private int? selectedSpecialtyId = null;
        private int? selectedAssignmentId = null;

        public AssignmentView()
        {
            InitializeComponent();
            LoadSpecialties();
            LoadSubjects();
            LoadTeachers();
            for (int i = 1; i <= 8; i++)
                SemesterComboBox.Items.Add(i);
        }

        private void LoadSpecialties()
        {
            string query = "SELECT id, name FROM specialties";
            using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                SpecialtyComboBox.ItemsSource = dt.DefaultView;
                SpecialtyComboBox.DisplayMemberPath = "name";
                SpecialtyComboBox.SelectedValuePath = "id";
            }
        }

        private void LoadSubjects()
        {
            string query = "SELECT id, name FROM subjects";
            using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                SubjectComboBox.ItemsSource = dt.DefaultView;
                SubjectComboBox.DisplayMemberPath = "name";
                SubjectComboBox.SelectedValuePath = "id";
            }
        }

        private void LoadTeachers()
        {
            string query = "SELECT id, last_name, first_name, middle_name FROM teachers";
            using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    row["middle_name"] = row["middle_name"] == DBNull.Value ? "" : row["middle_name"];
                }

                var teacherList = dt.AsEnumerable().Select(row => new
                {
                    Id = row.Field<int>("id"),
                    FullName = $"{row.Field<string>("last_name")} {row.Field<string>("first_name")} {row.Field<string>("middle_name")}"
                }).ToList();

                TeacherComboBox.ItemsSource = teacherList;
                TeacherComboBox.DisplayMemberPath = "FullName";
                TeacherComboBox.SelectedValuePath = "Id";

                EditTeacherComboBox.ItemsSource = teacherList;
                EditTeacherComboBox.DisplayMemberPath = "FullName";
                EditTeacherComboBox.SelectedValuePath = "Id";
            }
        }

        private void SpecialtyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedSpecialtyId = (int?)SpecialtyComboBox.SelectedValue;
            if (selectedSpecialtyId.HasValue)
            {
                LoadAssignments();
                AddAssignmentButton.IsEnabled = true;
            }
            else
            {
                AssignmentsGrid.ItemsSource = null;
                AddAssignmentButton.IsEnabled = false;
            }
        }

        private void LoadAssignments()
        {
            if (!selectedSpecialtyId.HasValue) return;

            string query = @"
                SELECT sa.id, sa.semester, 
                       s.name AS subject_name, 
                       CONCAT(t.last_name, ' ', t.first_name, ' ', ISNULL(t.middle_name, '')) AS teacher_name
                FROM subject_assignments sa
                INNER JOIN subjects s ON sa.subject_id = s.id
                LEFT JOIN teachers t ON sa.teacher_id = t.id
                WHERE sa.specialty_id = @SpecialtyId
                ORDER BY sa.semester";

            using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SpecialtyId", selectedSpecialtyId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var items = dt.AsEnumerable().Select(row => new
                {
                    Id = row.Field<int>("id"),
                    Semester = row.Field<int>("semester"),
                    SubjectName = row.Field<string>("subject_name"),
                    TeacherFullName = row.Field<string>("teacher_name")
                }).ToList();

                AssignmentsGrid.ItemsSource = items;
            }
        }

        private void AddAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!selectedSpecialtyId.HasValue ||
                SemesterComboBox.SelectedItem == null ||
                SubjectComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заповніть усі обов'язкові поля.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int semester = (int)SemesterComboBox.SelectedItem;
            int subjectId = (int)SubjectComboBox.SelectedValue;
            object teacherId = TeacherComboBox.SelectedValue ?? (object)DBNull.Value;

            string query = "INSERT INTO subject_assignments (semester, subject_id, teacher_id, specialty_id) VALUES (@sem, @subj, @teacher, @spec)";
            using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@sem", semester);
                cmd.Parameters.AddWithValue("@subj", subjectId);
                cmd.Parameters.AddWithValue("@teacher", teacherId);
                cmd.Parameters.AddWithValue("@spec", selectedSpecialtyId);
                cmd.ExecuteNonQuery();
            }

            LoadAssignments();
        }

        private void AssignmentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssignmentsGrid.SelectedItem is null)
            {
                EditDeletePanel.IsEnabled = false;
                selectedAssignmentId = null;
                return;
            }

            dynamic selected = AssignmentsGrid.SelectedItem;
            selectedAssignmentId = selected.Id;
            EditDeletePanel.IsEnabled = true;
        }

        private void UpdateAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAssignmentId == null || EditTeacherComboBox.SelectedValue == null)
            {
                MessageBox.Show("Виберіть викладача.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int teacherId = (int)EditTeacherComboBox.SelectedValue;

            string query = "UPDATE subject_assignments SET teacher_id = @teacherId WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@teacherId", teacherId);
                cmd.Parameters.AddWithValue("@id", selectedAssignmentId);
                cmd.ExecuteNonQuery();
            }

            LoadAssignments();
        }

        private void DeleteAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAssignmentId == null) return;

            var result = MessageBox.Show("Ви впевнені, що хочете видалити цей запис?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM subject_assignments WHERE id = @id";
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", selectedAssignmentId);
                    cmd.ExecuteNonQuery();
                }

                LoadAssignments();
            }
        }
    }
}
