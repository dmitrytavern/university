using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using UniversityServer.Components;
using UniversityServer.Database;

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