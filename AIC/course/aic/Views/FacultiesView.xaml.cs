using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace aic.Views
{
    public class Faculty : INotifyPropertyChanged
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

    public partial class FacultiesView : UserControl
    {
        private ObservableCollection<Faculty> _faculties;

        public FacultiesView()
        {
            InitializeComponent();
            _faculties = new ObservableCollection<Faculty>();
            FacultiesGrid.ItemsSource = _faculties;
            LoadFaculties();
        }

        private void LoadFaculties()
        {
            _faculties.Clear();
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
                                _faculties.Add(new Faculty
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
                MessageBox.Show($"Database error: {ex.Message}", "Error Loading Faculties", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddFacultyButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = NewFacultyNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Faculty name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (newName.Length > 128)
            {
                MessageBox.Show("Faculty name cannot exceed 128 characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            string query = "INSERT INTO faculties (name) VALUES (@Name)";
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
                            NewFacultyNameTextBox.Clear();
                            LoadFaculties();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Database error: A faculty with the name '{newName}' might already exist or another constraint was violated. Details: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error Adding Faculty", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FacultiesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FacultiesGrid.SelectedItem is Faculty selectedFaculty)
            {
                SelectedFacultyNameTextBox.Text = selectedFaculty.Name;
                EditDeleteSection.IsEnabled = true;
            }
            else
            {
                SelectedFacultyNameTextBox.Clear();
                EditDeleteSection.IsEnabled = false;
            }
        }

        private void UpdateFacultyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(FacultiesGrid.SelectedItem is Faculty selectedFaculty))
            {
                MessageBox.Show("Please select a faculty to update.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string updatedName = SelectedFacultyNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(updatedName))
            {
                MessageBox.Show("Faculty name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (updatedName.Length > 128)
            {
                MessageBox.Show("Faculty name cannot exceed 128 characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (updatedName == selectedFaculty.Name)
            {
                MessageBox.Show("No changes made to the faculty name.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string query = "UPDATE faculties SET name = @Name WHERE id = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", updatedName);
                        command.Parameters.AddWithValue("@Id", selectedFaculty.Id);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            LoadFaculties();
                            FacultiesGrid.SelectedItem = null;
                            SelectedFacultyNameTextBox.Clear();
                            EditDeleteSection.IsEnabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Faculty not found or no changes made.", "Update Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show($"Database error: A faculty with the name '{updatedName}' might already exist or another constraint was violated. Details: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error Updating Faculty", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteFacultyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(FacultiesGrid.SelectedItem is Faculty selectedFaculty))
            {
                MessageBox.Show("Please select a faculty to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult confirmation = MessageBox.Show($"Ви впевнені, що хочете видалити факультет '{selectedFaculty.Name}' (ID: {selectedFaculty.Id})?",
                                                           "Так", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM faculties WHERE id = @Id";
                try
                {
                    using (SqlConnection connection = new SqlConnection(App.GetDatabaseConnectionString()))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedFaculty.Id);
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                LoadFaculties();
                                SelectedFacultyNameTextBox.Clear();
                                EditDeleteSection.IsEnabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Faculty not found.", "Delete Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show($"Cannot delete faculty '{selectedFaculty.Name}' because it is referenced by other records (e.g., courses, instructors). Please remove those references first. Details: {ex.Message}", "Deletion Blocked", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Database error: {ex.Message}", "Error Deleting Faculty", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
