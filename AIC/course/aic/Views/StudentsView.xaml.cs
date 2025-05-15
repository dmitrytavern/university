using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace aic.Views
{
    public class Student : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class GroupDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class StudentsView : UserControl
    {
        private readonly ObservableCollection<Student> _students = new();
        private readonly ObservableCollection<GroupDisplay> _groups = new();

        public StudentsView()
        {
            InitializeComponent();
            StudentsGrid.ItemsSource = _students;
            NewStudentGroupComboBox.ItemsSource = _groups;
            SelectedStudentGroupComboBox.ItemsSource = _groups;
            LoadGroups();
            LoadStudents();
        }

        private void LoadGroups()
        {
            _groups.Clear();
            string query = "SELECT id, name FROM groups ORDER BY name";
            using SqlConnection conn = new(App.GetDatabaseConnectionString());
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                _groups.Add(new GroupDisplay
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
        }

        private void LoadStudents()
        {
            _students.Clear();
            string query = @"
            SELECT s.id, s.first_name, s.last_name, s.middle_name, s.group_id, g.name 
            FROM students s
            JOIN groups g ON s.group_id = g.id
            ORDER BY s.last_name, s.first_name";
            using SqlConnection conn = new(App.GetDatabaseConnectionString());
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                _students.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    MiddleName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    GroupId = reader.GetInt32(4),
                    GroupName = reader.GetString(5)
                });
            }
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string fn = NewStudentFirstNameTextBox.Text.Trim();
            string ln = NewStudentLastNameTextBox.Text.Trim();
            string mn = NewStudentMiddleNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(fn) || string.IsNullOrWhiteSpace(ln))
            {
                MessageBox.Show("Ім’я та прізвище не можуть бути порожніми.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (NewStudentGroupComboBox.SelectedValue is not int groupId)
            {
                MessageBox.Show("Будь ласка, оберіть групу.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string query = "INSERT INTO students (first_name, last_name, middle_name, group_id) VALUES (@fn, @ln, @mn, @gid)";
            using SqlConnection conn = new(App.GetDatabaseConnectionString());
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@fn", fn);
            cmd.Parameters.AddWithValue("@ln", ln);
            cmd.Parameters.AddWithValue("@mn", string.IsNullOrEmpty(mn) ? DBNull.Value : mn);
            cmd.Parameters.AddWithValue("@gid", groupId);
            cmd.ExecuteNonQuery();

            NewStudentFirstNameTextBox.Clear();
            NewStudentLastNameTextBox.Clear();
            NewStudentMiddleNameTextBox.Clear();
            NewStudentGroupComboBox.SelectedIndex = -1;
            LoadStudents();
        }

        private void StudentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentsGrid.SelectedItem is not Student selected)
            {
                EditDeleteSection.IsEnabled = false;
                return;
            }

            SelectedStudentFirstNameTextBox.Text = selected.FirstName;
            SelectedStudentLastNameTextBox.Text = selected.LastName;
            SelectedStudentMiddleNameTextBox.Text = selected.MiddleName;
            SelectedStudentGroupComboBox.SelectedValue = selected.GroupId;
            EditDeleteSection.IsEnabled = true;
        }

        private void UpdateStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsGrid.SelectedItem is not Student selected) return;

            string fn = SelectedStudentFirstNameTextBox.Text.Trim();
            string ln = SelectedStudentLastNameTextBox.Text.Trim();
            string mn = SelectedStudentMiddleNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(fn) || string.IsNullOrWhiteSpace(ln)) return;
            if (SelectedStudentGroupComboBox.SelectedValue is not int groupId) return;

            string query = "UPDATE students SET first_name=@fn, last_name=@ln, middle_name=@mn, group_id=@gid WHERE id=@id";
            using SqlConnection conn = new(App.GetDatabaseConnectionString());
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@fn", fn);
            cmd.Parameters.AddWithValue("@ln", ln);
            cmd.Parameters.AddWithValue("@mn", string.IsNullOrEmpty(mn) ? DBNull.Value : mn);
            cmd.Parameters.AddWithValue("@gid", groupId);
            cmd.Parameters.AddWithValue("@id", selected.Id);
            cmd.ExecuteNonQuery();

            LoadStudents();
        }

        private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsGrid.SelectedItem is not Student selected) return;

            if (MessageBox.Show("Ви впевнені, що хочете видалити цього студента?", "Підтвердження видалення",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                return;

            string query = "DELETE FROM students WHERE id=@id";
            using SqlConnection conn = new(App.GetDatabaseConnectionString());
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@id", selected.Id);
            cmd.ExecuteNonQuery();

            LoadStudents();
        }
    }
}
