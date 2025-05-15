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
    public class Specialty : INotifyPropertyChanged
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

        private int _departmentId;
        public int DepartmentId
        {
            get => _departmentId;
            set { _departmentId = value; OnPropertyChanged(nameof(DepartmentId)); }
        }

        private string _departmentName;
        public string DepartmentName
        {
            get => _departmentName;
            set { _departmentName = value; OnPropertyChanged(nameof(DepartmentName)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DepartmentDisplayForSpecialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }

    public partial class SpecialtiesView : UserControl
    {
        private ObservableCollection<Specialty> _specialties;
        private ObservableCollection<DepartmentDisplayForSpecialty> _departmentsForComboBox;

        public SpecialtiesView()
        {
            InitializeComponent();
            _specialties = new ObservableCollection<Specialty>();
            _departmentsForComboBox = new ObservableCollection<DepartmentDisplayForSpecialty>();
            SpecialtiesGrid.ItemsSource = _specialties;
            NewSpecialtyDepartmentComboBox.ItemsSource = _departmentsForComboBox;
            SelectedSpecialtyDepartmentComboBox.ItemsSource = _departmentsForComboBox;
            LoadDepartmentsForComboBox();
            LoadSpecialties();
        }

        private void LoadDepartmentsForComboBox()
        {
            _departmentsForComboBox.Clear();
            string query = "SELECT id, name FROM departments ORDER BY name";
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
                                _departmentsForComboBox.Add(new DepartmentDisplayForSpecialty
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
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка завантаження кафедр", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadSpecialties()
        {
            _specialties.Clear();
            string query = "SELECT s.id, s.name, s.department_id, d.name AS department_name FROM specialties s JOIN departments d ON s.department_id = d.id ORDER BY s.name";
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
                                _specialties.Add(new Specialty
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    DepartmentId = reader.GetInt32(2),
                                    DepartmentName = reader.GetString(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка завантаження спеціальностей", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddSpecialtyButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = NewSpecialtyNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Назва спеціальності не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (newName.Length > 128)
            {
                MessageBox.Show("Назва спеціальності не може перевищувати 128 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (NewSpecialtyDepartmentComboBox.SelectedValue == null)
            {
                MessageBox.Show("Будь ласка, оберіть кафедру.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int departmentId = (int)NewSpecialtyDepartmentComboBox.SelectedValue;

            string query = "INSERT INTO specialties (name, department_id) VALUES (@Name, @DepartmentId)";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", newName);
                        command.Parameters.AddWithValue("@DepartmentId", departmentId);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            NewSpecialtyNameTextBox.Clear();
                            NewSpecialtyDepartmentComboBox.SelectedIndex = -1;
                            LoadSpecialties();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Помилка бази даних: Спеціальність з назвою '{newName}' можливо вже існує, або було порушено інше обмеження. Деталі: {ex.Message}", "Помилка бази даних", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка додавання спеціальності", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SpecialtiesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SpecialtiesGrid.SelectedItem is Specialty selectedSpecialty)
            {
                SelectedSpecialtyNameTextBox.Text = selectedSpecialty.Name;
                SelectedSpecialtyDepartmentComboBox.SelectedValue = selectedSpecialty.DepartmentId;
                EditDeleteSection.IsEnabled = true;
            }
            else
            {
                SelectedSpecialtyNameTextBox.Clear();
                SelectedSpecialtyDepartmentComboBox.SelectedIndex = -1;
                EditDeleteSection.IsEnabled = false;
            }
        }

        private void UpdateSpecialtyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SpecialtiesGrid.SelectedItem is Specialty selectedSpecialty))
            {
                MessageBox.Show("Будь ласка, оберіть спеціальність для оновлення.", "Нічого не вибрано", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string updatedName = SelectedSpecialtyNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(updatedName))
            {
                MessageBox.Show("Назва спеціальності не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (updatedName.Length > 128)
            {
                MessageBox.Show("Назва спеціальності не може перевищувати 128 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (SelectedSpecialtyDepartmentComboBox.SelectedValue == null)
            {
                MessageBox.Show("Будь ласка, оберіть кафедру.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int updatedDepartmentId = (int)SelectedSpecialtyDepartmentComboBox.SelectedValue;

            if (updatedName == selectedSpecialty.Name && updatedDepartmentId == selectedSpecialty.DepartmentId)
            {
                MessageBox.Show("Змін до спеціальності не внесено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string query = "UPDATE specialties SET name = @Name, department_id = @DepartmentId WHERE id = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", updatedName);
                        command.Parameters.AddWithValue("@DepartmentId", updatedDepartmentId);
                        command.Parameters.AddWithValue("@Id", selectedSpecialty.Id);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            LoadSpecialties();
                            SpecialtiesGrid.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Спеціальність не знайдено або змін не внесено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Помилка бази даних: Спеціальність з назвою '{updatedName}' можливо вже існує, або було порушено інше обмеження. Деталі: {ex.Message}", "Помилка бази даних", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка оновлення спеціальності", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteSpecialtyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SpecialtiesGrid.SelectedItem is Specialty selectedSpecialty))
            {
                MessageBox.Show("Будь ласка, оберіть спеціальність для видалення.", "Нічого не вибрано", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult confirmation = MessageBox.Show($"Ви впевнені, що хочете видалити спеціальність '{selectedSpecialty.Name}' (ID: {selectedSpecialty.Id})?",
                                                           "Підтвердити видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM specialties WHERE id = @Id";
                try
                {
                    using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedSpecialty.Id);
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                LoadSpecialties();
                                SpecialtiesGrid.SelectedItem = null;
                            }
                            else
                            {
                                MessageBox.Show("Спеціальність не знайдено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show($"Неможливо видалити спеціальність '{selectedSpecialty.Name}', оскільки на неї посилаються інші записи. Будь ласка, спочатку видаліть ці посилання. Деталі: {ex.Message}", "Видалення заблоковано", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Помилка бази даних: {ex.Message}", "Помилка видалення спеціальності", MessageBoxButton.OK, MessageBoxImage.Error);
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
