using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace UniversityClient
{
    public partial class MainWindow : Window
    {
        public static Frame MainFrame { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainFrame = navframe;
        }
    }
}
