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
    public class Subject : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class SubjectsView : UserControl
    {
        private ObservableCollection<Subject> _subjects;

        public SubjectsView()
        {
            InitializeComponent();
            _subjects = new ObservableCollection<Subject>();
            SubjectsGrid.ItemsSource = _subjects;
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            _subjects.Clear();
            string query = "SELECT id, name FROM subjects ORDER BY name";
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
                                _subjects.Add(new Subject
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
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка завантаження предметів", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = NewSubjectNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Назва предмету не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (newName.Length > 128)
            {
                MessageBox.Show("Назва предмету не може перевищувати 128 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string query = "INSERT INTO subjects (name) VALUES (@Name)";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", newName);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            NewSubjectNameTextBox.Clear();
                            LoadSubjects();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Помилка бази даних: Предмет з назвою '{newName}' можливо вже існує, або було порушено інше обмеження. Деталі: {ex.Message}", "Помилка бази даних", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка додавання предмету", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubjectsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubjectsGrid.SelectedItem is Subject selectedSubject)
            {
                SelectedSubjectNameTextBox.Text = selectedSubject.Name;
                EditDeleteSection.IsEnabled = true;
            }
            else
            {
                SelectedSubjectNameTextBox.Clear();
                EditDeleteSection.IsEnabled = false;
            }
        }

        private void UpdateSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SubjectsGrid.SelectedItem is Subject selectedSubject))
            {
                MessageBox.Show("Будь ласка, оберіть предмет для оновлення.", "Нічого не вибрано", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string updatedName = SelectedSubjectNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(updatedName))
            {
                MessageBox.Show("Назва предмету не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (updatedName.Length > 128)
            {
                MessageBox.Show("Назва предмету не може перевищувати 128 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (updatedName == selectedSubject.Name)
            {
                MessageBox.Show("Змін до назви предмету не внесено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string query = "UPDATE subjects SET name = @Name WHERE id = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", updatedName);
                        command.Parameters.AddWithValue("@Id", selectedSubject.Id);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            LoadSubjects();
                            SubjectsGrid.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Предмет не знайдено або змін не внесено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Помилка бази даних: Предмет з назвою '{updatedName}' можливо вже існує, або було порушено інше обмеження. Деталі: {ex.Message}", "Помилка бази даних", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка оновлення предмету", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SubjectsGrid.SelectedItem is Subject selectedSubject))
            {
                MessageBox.Show("Будь ласка, оберіть предмет для видалення.", "Нічого не вибрано", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult confirmation = MessageBox.Show($"Ви впевнені, що хочете видалити предмет '{selectedSubject.Name}' (ID: {selectedSubject.Id})?",
                                                           "Підтвердити видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM subjects WHERE id = @Id";
                try
                {
                    using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedSubject.Id);
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                LoadSubjects();
                                SubjectsGrid.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Предмет не знайдено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show($"Неможливо видалити предмет '{selectedSubject.Name}', оскільки на нього посилаються інші записи. Будь ласка, спочатку видаліть ці посилання. Деталі: {ex.Message}", "Видалення заблоковано", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка видалення предмету", MessageBoxButton.OK, MessageBoxImage.Error);
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
