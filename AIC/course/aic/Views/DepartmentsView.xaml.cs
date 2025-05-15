using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class Department : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private int _facultyId;
        public int FacultyId
        {
            get => _facultyId;
            set { _facultyId = value; OnPropertyChanged(nameof(FacultyId)); }
        }

        private string _facultyName;
        public string FacultyName
        {
            get => _facultyName;
            set { _facultyName = value; OnPropertyChanged(nameof(FacultyName)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FacultyDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }

    public partial class DepartmentsView : UserControl
    {
        private ObservableCollection<Department> _departments;
        private ObservableCollection<FacultyDisplay> _facultiesForComboBox;

        public DepartmentsView()
        {
            InitializeComponent();
            _departments = new ObservableCollection<Department>();
            _facultiesForComboBox = new ObservableCollection<FacultyDisplay>();
            DepartmentsGrid.ItemsSource = _departments;
            NewDepartmentFacultyComboBox.ItemsSource = _facultiesForComboBox;
            SelectedDepartmentFacultyComboBox.ItemsSource = _facultiesForComboBox;
            LoadFacultiesForComboBox();
            LoadDepartments();
        }

        private void LoadFacultiesForComboBox()
        {
            _facultiesForComboBox.Clear();
            string query = "SELECT id, name FROM faculties ORDER BY name";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _facultiesForComboBox.Add(new FacultyDisplay
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка завантаження факультетів", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadDepartments()
        {
            _departments.Clear();
            string query = "SELECT d.id, d.name, d.faculty_id, f.name AS faculty_name FROM departments d JOIN faculties f ON d.faculty_id = f.id ORDER BY d.name";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _departments.Add(new Department
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    FacultyId = reader.GetInt32(2),
                                    FacultyName = reader.GetString(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка завантаження кафедр", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = NewDepartmentNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Назва кафедри не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (newName.Length > 128)
            {
                MessageBox.Show("Назва кафедри не може перевищувати 128 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (NewDepartmentFacultyComboBox.SelectedValue == null)
            {
                MessageBox.Show("Будь ласка, оберіть факультет.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int facultyId = (int)NewDepartmentFacultyComboBox.SelectedValue;

            string query = "INSERT INTO departments (name, faculty_id) VALUES (@Name, @FacultyId)";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", newName);
                        command.Parameters.AddWithValue("@FacultyId", facultyId);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            NewDepartmentNameTextBox.Clear();
                            NewDepartmentFacultyComboBox.SelectedIndex = -1;
                            LoadDepartments();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Помилка бази даних: Кафедра з назвою '{newName}' можливо вже існує, або було порушено інше обмеження. Деталі: {ex.Message}", "Помилка бази даних", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка додавання кафедри", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DepartmentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartmentsGrid.SelectedItem is Department selectedDepartment)
            {
                SelectedDepartmentNameTextBox.Text = selectedDepartment.Name;
                SelectedDepartmentFacultyComboBox.SelectedValue = selectedDepartment.FacultyId;
                EditDeleteSection.IsEnabled = true;
            }
            else
            {
                SelectedDepartmentNameTextBox.Clear();
                SelectedDepartmentFacultyComboBox.SelectedIndex = -1;
                EditDeleteSection.IsEnabled = false;
            }
        }

        private void UpdateDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(DepartmentsGrid.SelectedItem is Department selectedDepartment))
            {
                MessageBox.Show("Будь ласка, оберіть кафедру для оновлення.", "Нічого не вибрано", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string updatedName = SelectedDepartmentNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(updatedName))
            {
                MessageBox.Show("Назва кафедри не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (updatedName.Length > 128)
            {
                MessageBox.Show("Назва кафедри не може перевищувати 128 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (SelectedDepartmentFacultyComboBox.SelectedValue == null)
            {
                MessageBox.Show("Будь ласка, оберіть факультет.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int updatedFacultyId = (int)SelectedDepartmentFacultyComboBox.SelectedValue;

            if (updatedName == selectedDepartment.Name && updatedFacultyId == selectedDepartment.FacultyId)
            {
                MessageBox.Show("Змін до кафедри не внесено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string query = "UPDATE departments SET name = @Name, faculty_id = @FacultyId WHERE id = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", updatedName);
                        command.Parameters.AddWithValue("@FacultyId", updatedFacultyId);
                        command.Parameters.AddWithValue("@Id", selectedDepartment.Id);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            LoadDepartments();
                            DepartmentsGrid.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Кафедру не знайдено або змін не внесено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Помилка бази даних: Кафедра з назвою '{updatedName}' можливо вже існує, або було порушено інше обмеження. Деталі: {ex.Message}", "Помилка бази даних", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка оновлення кафедри", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(DepartmentsGrid.SelectedItem is Department selectedDepartment))
            {
                MessageBox.Show("Будь ласка, оберіть кафедру для видалення.", "Нічого не вибрано", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult confirmation = MessageBox.Show($"Ви впевнені, що хочете видалити кафедру '{selectedDepartment.Name}' (ID: {selectedDepartment.Id})?",
                                                           "Підтвердити видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM departments WHERE id = @Id";
                try
                {
                    using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedDepartment.Id);
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                LoadDepartments();
                                DepartmentsGrid.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Кафедру не знайдено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show($"Неможливо видалити кафедру '{selectedDepartment.Name}', оскільки на неї посилаються інші записи. Будь ласка, спочатку видаліть ці посилання. Деталі: {ex.Message}", "Видалення заблоковано", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка видалення кафедри", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
