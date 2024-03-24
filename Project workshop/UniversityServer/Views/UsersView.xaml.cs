using System.Windows;
using System.Windows.Controls;
using UniversityServer.Database;
using UniversityServer.ViewModels;

namespace UniversityServer.Views
{
    public partial class UsersView : UserControl
    {
        private readonly UsersViewModel viewModel = new();

        public UsersView()
        {
            InitializeComponent();
            DataContext = viewModel;
            FetchTeachersList();
        }

        private void TeachersViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Teachers? teacher = (Teachers)TeachersViewList.SelectedItem;

                if (teacher != null)
                {
                    viewModel.InputTeacherName = teacher.name;
                    viewModel.InputTeacherSurname = teacher.surname;
                    viewModel.InputTeacherEmail = teacher.email;
                    viewModel.InputTeacherPassword = teacher.password;
                    EditButton.IsEnabled = true;
                    DeleteButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckFormValidation()) return;

                App.db.Teachers.InsertOnSubmit(CreateTeacherFromForm());
                App.db.SubmitChanges();

                ClearForm();

                FetchTeachersList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckFormValidation()) return;

                Teachers teacher = GetSelectedTeacher();

                Teachers dbTeacher = App.db.Teachers.Single(p => p.id == teacher.id);

                App.db.Teachers.DeleteOnSubmit(dbTeacher);
                App.db.SubmitChanges();

                ClearForm();

                FetchTeachersList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckFormValidation()) return;

                Teachers teacher = GetSelectedTeacher();

                Teachers dbTeacher = App.db.Teachers.Single(p => p.id == teacher.id);

                dbTeacher.name = viewModel.InputTeacherName;
                dbTeacher.surname = viewModel.InputTeacherSurname;
                dbTeacher.email = viewModel.InputTeacherEmail;
                dbTeacher.password = viewModel.InputTeacherPassword;

                App.db.SubmitChanges();

                FetchTeachersList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FetchTeachersList()
        {
            App.db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, App.db.Teachers);
            viewModel.Teachers = App.db.Teachers.ToList();
        }

        private Teachers GetSelectedTeacher()
        {
            return (Teachers)TeachersViewList.SelectedItem;
        }

        private Teachers CreateTeacherFromForm()
        {
            return new Teachers
            {
                name = viewModel.InputTeacherName,
                surname = viewModel.InputTeacherSurname,
                email = viewModel.InputTeacherEmail,
                password = viewModel.InputTeacherPassword
            };
        }

        private bool CheckFormValidation()
        {
            if (string.IsNullOrWhiteSpace(viewModel.InputTeacherName) ||
                string.IsNullOrWhiteSpace(viewModel.InputTeacherSurname) ||
                string.IsNullOrWhiteSpace(viewModel.InputTeacherEmail) ||
                string.IsNullOrWhiteSpace(viewModel.InputTeacherPassword))
            {
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            viewModel.InputTeacherName = "";
            viewModel.InputTeacherSurname = "";
            viewModel.InputTeacherEmail = "";
            viewModel.InputTeacherPassword = "";
        }
    }
}
