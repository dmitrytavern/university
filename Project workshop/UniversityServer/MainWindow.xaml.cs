using System.Windows;
using System.Windows.Controls;
using UniversityServer.Components;

namespace UniversityServer
{
   public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationButton? selected = sidebar.SelectedItem as NavigationButton;

            if (selected != null && navframe != null)
            {
                navframe.Navigate(selected.Navlink);
            }
        }
    }
}