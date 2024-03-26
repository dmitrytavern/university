using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using UniversityClient.ViewModels;
using UniversityServer.ViewModels;

namespace UniversityClient.Views
{
    /// <summary>
    /// Interaction logic for RatingView.xaml
    /// </summary>
    public partial class RatingView : UserControl
    {
        private readonly ClientRatingViewModel viewModel = new();

        /// <summary>
        /// Initializes a new instance of the RatingView class.
        /// </summary>
        public RatingView()
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.FetchRating();
            WpfPlot1.Plot.XLabel("Month");
            WpfPlot1.Plot.YLabel("Hours");
            WpfPlot1.Plot.Title("Hours per Month");
        }

        /// <summary>
        /// Handles the SelectionChanged event of the RatingViewList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The SelectionChangedEventArgs instance containing the event data.</param>
        private void RatingViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PrintButton.IsEnabled = true;

                DateTime[] dates = GetMonthsOfYear();

                double[] dataY = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                foreach (RatingRaportData report in ((RatingTeacherData)RatingViewList.SelectedItem).raports)
                {
                    dataY[report.date.Month - 1] += report.hours;
                }

                WpfPlot1.Plot.Clear();
                WpfPlot1.Plot.Axes.DateTimeTicksBottom();
                WpfPlot1.Plot.Axes.SetLimits(dates[0].ToOADate(), dates[11].ToOADate(), 0, 100);
                WpfPlot1.Plot.Add.Scatter(dates, dataY);
                WpfPlot1.Refresh();

                WpfPlot1.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Gets an array of DateTime representing each month of the year.
        /// </summary>
        /// <returns>An array of DateTime representing each month of the year.</returns>
        private DateTime[] GetMonthsOfYear()
        {
            DateTime[] months = new DateTime[12];
            DateTime currentDate = DateTime.Today;

            for (int i = 0; i < 12; i++)
            {
                months[i] = new DateTime(currentDate.Year, i + 1, 1);
            }

            return months;
        }

        /// <summary>
        /// Handles the Click event of the PrintButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;

                    WpfPlot1.Plot.SavePng(filePath, 400, 300);

                    MessageBox.Show("Graph successfully saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the BackButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new ProfileView());
        }
    }
}
