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
    public class Group : INotifyPropertyChanged
    {
        private int _id;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(nameof(Id)); } }

        private string _name;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }

        private int _created_year;
        public int CreatedYear { get => _created_year; set { _created_year = value; OnPropertyChanged(nameof(CreatedYear)); } }

        private int _specialtyId;
        public int SpecialtyId { get => _specialtyId; set { _specialtyId = value; OnPropertyChanged(nameof(SpecialtyId)); } }

        private string _specialtyName;
        public string SpecialtyName { get => _specialtyName; set { _specialtyName = value; OnPropertyChanged(nameof(SpecialtyName)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class SpecialtyDisplayForGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public partial class GroupsView : UserControl
    {
        private ObservableCollection<Group> _groups = new();
        private ObservableCollection<SpecialtyDisplayForGroup> _specialties = new();

        public GroupsView()
        {
            InitializeComponent();
            GroupsGrid.ItemsSource = _groups;
            NewGroupSpecialtyComboBox.ItemsSource = _specialties;
            SelectedGroupSpecialtyComboBox.ItemsSource = _specialties;
            LoadSpecialties();
            LoadGroups();
        }

        private void LoadSpecialties()
        {
            _specialties.Clear();
            string query = "SELECT id, name FROM specialties ORDER BY name";
            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _specialties.Add(new SpecialtyDisplayForGroup
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження спеціальностей: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadGroups()
        {
            _groups.Clear();
            string query = @"
            SELECT g.id, g.name, g.created_year, g.specialty_id, s.name as specialty_name
            FROM groups g
            JOIN specialties s ON g.specialty_id = s.id
            ORDER BY g.name";

            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _groups.Add(new Group
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CreatedYear = reader.GetInt32(2),
                        SpecialtyId = reader.GetInt32(3),
                        SpecialtyName = reader.GetString(4)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження груп: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = NewGroupNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName) || newName.Length > 16)
            {
                MessageBox.Show("Номер групи не може бути порожнім або довшим за 16 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(NewGroupCreatedYearTextBox.Text.Trim(), out int created_year))
            {
                MessageBox.Show("Рік створення має бути цілим числом.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NewGroupSpecialtyComboBox.SelectedValue is not int specialtyId)
            {
                MessageBox.Show("Оберіть спеціальність.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string query = "INSERT INTO groups (name, created_year, specialty_id) VALUES (@Name, @CreatedYear, @SpecialtyId)";
            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Name", newName);
                command.Parameters.AddWithValue("@CreatedYear", created_year);
                command.Parameters.AddWithValue("@SpecialtyId", specialtyId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    NewGroupNameTextBox.Clear();
                    NewGroupCreatedYearTextBox.Clear();
                    NewGroupSpecialtyComboBox.SelectedIndex = -1;
                    LoadGroups();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання групи: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GroupsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsGrid.SelectedItem is not Group selected) return;
            SelectedGroupNameTextBox.Text = selected.Name;
            SelectedGroupCreatedYearTextBox.Text = selected.CreatedYear.ToString();
            SelectedGroupSpecialtyComboBox.SelectedValue = selected.SpecialtyId;
            EditDeleteSection.IsEnabled = true;
        }

        private void UpdateGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsGrid.SelectedItem is not Group selected) return;

            string newName = SelectedGroupNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName) || newName.Length > 16)
            {
                MessageBox.Show("Номер групи не може бути порожнім або довшим за 16 символів.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(SelectedGroupCreatedYearTextBox.Text.Trim(), out int created_year))
            {
                MessageBox.Show("Рік створення має бути цілим числом.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (SelectedGroupSpecialtyComboBox.SelectedValue is not int specialtyId)
            {
                MessageBox.Show("Оберіть спеціальність.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string query = "UPDATE groups SET name = @Name, created_year = @CreatedYear, specialty_id = @SpecialtyId WHERE id = @Id";
            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Name", newName);
                command.Parameters.AddWithValue("@CreatedYear", created_year);
                command.Parameters.AddWithValue("@SpecialtyId", specialtyId);
                command.Parameters.AddWithValue("@Id", selected.Id);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    LoadGroups();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення групи: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsGrid.SelectedItem is not Group selected) return;
            if (MessageBox.Show("Ви дійсно хочете видалити цю групу?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;

            string query = "DELETE FROM groups WHERE id = @Id";
            try
            {
                using SqlConnection connection = new(App.GetDatabaseConnectionString());
                connection.Open();
                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Id", selected.Id);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    LoadGroups();
                    EditDeleteSection.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка видалення групи: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
