using aic.Views;
using System.Windows;
using System.Windows.Controls;

namespace aic
{
    public partial class MainWindow : Window
    {
        #pragma warning disable CS8618
        public static Frame MainFrame { get; set; }
        public static ListBox MainSidebar { get; set; }
        #pragma warning restore CS8618

        public MainWindow()
        {
            InitializeComponent();
            MainFrame = navframe;
            MainSidebar = Sidebar;
        }

        private void Sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Sidebar.SelectedItem is ListBoxItem item)
            {
                string? tag = item.Tag as string;

                switch (tag)
                {
                    case "dashboard":
                        MainFrame.Navigate(new DashboardView());
                        break;
                    case "faculties":
                        MainFrame.Navigate(new FacultiesView());
                        break;
                    case "departments":
                        MainFrame.Navigate(new DepartmentsView());
                        break;
                    case "specialties":
                        MainFrame.Navigate(new SpecialtiesView());
                        break;
                    case "subjects":
                        MainFrame.Navigate(new SubjectsView());
                        break;
                    case "teachers":
                        MainFrame.Navigate(new TeachersView());
                        break;
                    case "groups":
                        MainFrame.Navigate(new GroupsView());
                        break;
                    case "students":
                        MainFrame.Navigate(new StudentsView());
                        break;  
                    case "assignment":
                        MainFrame.Navigate(new AssignmentView());
                        break;
                    case "schedule":
                        MainFrame.Navigate(new Schedule());
                        break;
                    case "exit":
                        Application.Current.Shutdown();
                        break;
                }
            }
        }
    }
}