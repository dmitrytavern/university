using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace aic.Views
{
    public class Teacher : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private string _middleName;
        public string MiddleName
        {
            get => _middleName;
            set { _middleName = value; OnPropertyChanged(nameof(MiddleName)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class TeachersView : UserControl
    {
        private readonly ObservableCollection<Teacher> _teachers = new();

        public TeachersView()
        {
            InitializeComponent();
            TeachersGrid.ItemsSource = _teachers;
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            _teachers.Clear();
            string query = "SELECT id, first_name, last_name, middle_name FROM teachers ORDER BY last_name, first_name";

            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _teachers.Add(new Teacher
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        MiddleName = reader.IsDBNull(3) ? null : reader.GetString(3)
                    });
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка завантаження викладачів", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = NewTeacherFirstNameTextBox.Text.Trim();
            string lastName = NewTeacherLastNameTextBox.Text.Trim();
            string middleName = NewTeacherMiddleNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Ім’я та прізвище викладача є обов’язковими.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (firstName.Length > 28 || lastName.Length > 28 || middleName.Length > 28)
            {
                MessageBox.Show("Довжина полів не може перевищувати 28 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string query = "INSERT INTO teachers (first_name, last_name, middle_name) VALUES (@FirstName, @LastName, @MiddleName)";

            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@MiddleName", string.IsNullOrWhiteSpace(middleName) ? DBNull.Value : middleName);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    NewTeacherFirstNameTextBox.Clear();
                    NewTeacherLastNameTextBox.Clear();
                    NewTeacherMiddleNameTextBox.Clear();
                    LoadTeachers();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка додавання викладача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TeachersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeachersGrid.SelectedItem is Teacher selected)
            {
                SelectedTeacherFirstNameTextBox.Text = selected.FirstName;
                SelectedTeacherLastNameTextBox.Text = selected.LastName;
                SelectedTeacherMiddleNameTextBox.Text = selected.MiddleName;
                EditDeleteSection.IsEnabled = true;
            }
            else
            {
                EditDeleteSection.IsEnabled = false;
            }
        }

        private void UpdateTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeachersGrid.SelectedItem is not Teacher selected) return;

            string newFirstName = SelectedTeacherFirstNameTextBox.Text.Trim();
            string newLastName = SelectedTeacherLastNameTextBox.Text.Trim();
            string newMiddleName = SelectedTeacherMiddleNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(newFirstName) || string.IsNullOrWhiteSpace(newLastName))
            {
                MessageBox.Show("Ім’я та прізвище викладача є обов’язковими.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (newFirstName.Length > 28 || newLastName.Length > 28 || newMiddleName.Length > 28)
            {
                MessageBox.Show("Довжина полів не може перевищувати 28 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string query = "UPDATE teachers SET first_name = @FirstName, last_name = @LastName, middle_name = @MiddleName WHERE id = @Id";

            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@FirstName", newFirstName);
                command.Parameters.AddWithValue("@LastName", newLastName);
                command.Parameters.AddWithValue("@MiddleName", string.IsNullOrWhiteSpace(newMiddleName) ? DBNull.Value : newMiddleName);
                command.Parameters.AddWithValue("@Id", selected.Id);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    LoadTeachers();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка оновлення викладача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeachersGrid.SelectedItem is not Teacher selected) return;

            if (MessageBox.Show("Ви впевнені, що хочете видалити викладача?", "Підтвердження видалення", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            string query = "DELETE FROM teachers WHERE id = @Id";

            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Id", selected.Id);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    LoadTeachers();
                    EditDeleteSection.IsEnabled = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка видалення викладача", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
