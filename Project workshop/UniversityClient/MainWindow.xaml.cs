using System.Windows;
using System.Windows.Controls;

namespace UniversityClient
{
    /// <summary>
    /// Represents the main window of the application.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Gets or sets the main frame used for navigation.
        /// </summary>
        public static Frame MainFrame { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MainFrame = navframe;
        }
    }
}