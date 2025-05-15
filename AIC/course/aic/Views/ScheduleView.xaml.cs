using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : UserControl
    {
        public class GroupDisplay
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
        }

        public class ScheduleEntry
        {
            public int Semester { get; set; }
            public string SubjectName { get; set; }
            public string TeacherFullName { get; set; }
        }

        private List<GroupDisplay> _availableGroups = new();
        private List<ScheduleEntry> _schedule = new();

        public Schedule()
        {
            InitializeComponent();
            LoadAvailableGroups();
        }

        private void LoadAvailableGroups()
        {
            _availableGroups.Clear();
            GroupComboBox.ItemsSource = null;

            string query = @"
            SELECT id, name, created_year 
            FROM groups 
            WHERE @CurrentYear - created_year >= 0 AND @CurrentYear - created_year < 4
            ORDER BY created_year DESC, name";

            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@CurrentYear", App.CurrentYear);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _availableGroups.Add(new GroupDisplay
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Year = reader.GetInt32(2)
                    });
                }
                GroupComboBox.ItemsSource = _availableGroups;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження груп: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupComboBox.SelectedItem is GroupDisplay selectedGroup)
            {
                LoadScheduleForGroup(selectedGroup);
            }
        }

        private void LoadScheduleForGroup(GroupDisplay group)
        {
            _schedule.Clear();
            ScheduleDataGrid.ItemsSource = null;

            int actualSemester = (App.CurrentYear - group.Year) * 2 + App.CurrentSemester;

            string studentCountQuery = "SELECT COUNT(*) FROM students WHERE group_id = @GroupId";
            string specialtyQuery = "SELECT specialty_id FROM groups WHERE id = @GroupId";
            string scheduleQuery = @"
            SELECT 
                sa.semester, 
                s.name AS subject_name, 
                CONCAT(t.last_name, ' ', t.first_name, ' ', ISNULL(t.middle_name, '')) AS teacher_name
            FROM subject_assignments sa
            JOIN subjects s ON sa.subject_id = s.id
            LEFT JOIN teachers t ON sa.teacher_id = t.id
            WHERE sa.specialty_id = @SpecialtyId AND sa.semester = @Semester
            ORDER BY sa.semester, s.name";

            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();

                int studentCount = 0;
                using (SqlCommand countCommand = new(studentCountQuery, connection))
                {
                    countCommand.Parameters.AddWithValue("@GroupId", group.Id);
                    studentCount = (int)countCommand.ExecuteScalar();
                }

                int specialtyId = 0;
                using (SqlCommand specCommand = new(specialtyQuery, connection))
                {
                    specCommand.Parameters.AddWithValue("@GroupId", group.Id);
                    specialtyId = (int)specCommand.ExecuteScalar();
                }

                using (SqlCommand scheduleCommand = new(scheduleQuery, connection))
                {
                    scheduleCommand.Parameters.AddWithValue("@SpecialtyId", specialtyId);
                    scheduleCommand.Parameters.AddWithValue("@Semester", actualSemester);
                    using SqlDataReader reader = scheduleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        _schedule.Add(new ScheduleEntry
                        {
                            Semester = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            TeacherFullName = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim()
                        });
                    }
                }

                GroupInfoTextBlock.Text = $"Група: {group.Name} | Студентів: {studentCount} | Семестр: {actualSemester}";
                ScheduleDataGrid.ItemsSource = _schedule;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні розкладу: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
