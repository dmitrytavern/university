using System.Windows;
using System.Windows.Controls;
using UniversityServer.Database;
using UniversityServer.ViewModels;

namespace UniversityServer.Views
{
    public partial class RaportsView : UserControl
    {
        private readonly RaportsViewModel viewModel = new();

        public RaportsView()
        {
            InitializeComponent();
            DataContext = viewModel;

            RaportsViewList.IsEnabled = App.db != null;
            RaportTeacherIdInput.IsEnabled = App.db != null;
            RaportNameInput.IsEnabled = App.db != null;
            RaportHoursInput.IsEnabled = App.db != null;
            RaportDateInput.IsEnabled = App.db != null;
            EditButton.IsEnabled = App.db != null;
            DeleteButton.IsEnabled = App.db != null;
            CreateButton.IsEnabled = App.db != null;

            if (App.db != null)
            {
                FetchRaportsList();
            }
        }

        private void RaportsViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Raports? raport = (Raports)RaportsViewList.SelectedItem;

                if (raport != null)
                {
                    viewModel.InputRaportTeacherId = raport.teacher_id.ToString();
                    viewModel.InputRaportName = raport.name;
                    viewModel.InputRaportHours = raport.hours.ToString();
                    viewModel.InputRaportDate = raport.date.ToString();
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

                int teacher_id = int.Parse(viewModel.InputRaportTeacherId);

                App.db.Teachers.Single(p => p.id == teacher_id);

                App.db.Raports.InsertOnSubmit(CreateRaportFromForm());
                App.db.SubmitChanges();

                ClearForm();

                FetchRaportsList();
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

                Raports raport = GetSelectedRaport();

                Raports dbRaport = App.db.Raports.Single(p => p.id == raport.id);

                App.db.Raports.DeleteOnSubmit(dbRaport);
                App.db.SubmitChanges();

                ClearForm();

                FetchRaportsList();
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


                Raports raport = GetSelectedRaport();

                Raports dbRaport = App.db.Raports.Single(p => p.id == raport.id);

                int teacher_id = int.Parse(viewModel.InputRaportTeacherId);

                App.db.Teachers.Single(p => p.id == teacher_id);

                dbRaport.teacher_id = int.Parse(viewModel.InputRaportTeacherId);
                dbRaport.name = viewModel.InputRaportName;
                dbRaport.hours = double.Parse(viewModel.InputRaportHours);
                dbRaport.date = DateTime.Parse(viewModel.InputRaportDate);

                App.db.SubmitChanges();

                FetchRaportsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FetchRaportsList()
        {
            try
            {
                App.db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, App.db.Raports);
                viewModel.Raports = App.db.Raports.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Raports GetSelectedRaport()
        {
            return (Raports)RaportsViewList.SelectedItem;
        }

        private Raports CreateRaportFromForm()
        {
            return new Raports
            {
                teacher_id = int.Parse(viewModel.InputRaportTeacherId),
                name = viewModel.InputRaportName,
                hours = double.Parse(viewModel.InputRaportHours),
                date = DateTime.Parse(viewModel.InputRaportDate),
            };
        }

        private bool CheckFormValidation()
        {
            if (string.IsNullOrWhiteSpace(viewModel.InputRaportTeacherId) ||
                string.IsNullOrWhiteSpace(viewModel.InputRaportName) ||
                string.IsNullOrWhiteSpace(viewModel.InputRaportHours) ||
                string.IsNullOrWhiteSpace(viewModel.InputRaportDate))
            {
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            viewModel.InputRaportTeacherId = "";
            viewModel.InputRaportName = "";
            viewModel.InputRaportHours = "";
            viewModel.InputRaportDate = "";
            RaportsViewList.SelectedIndex = -1;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }
    }
}
