using Microsoft.Win32;
using ScottPlot;
using System.Windows;
using System.Windows.Controls;
using UniversityServer.Database;
using UniversityServer.ViewModels;

namespace UniversityServer.Views
{
    public partial class RatingView : UserControl
    {
        private readonly RatingViewModel viewModel = new();

        public RatingView()
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.FetchRating();
            WpfPlot1.Plot.XLabel("Mouth");
            WpfPlot1.Plot.YLabel("Hours");
            WpfPlot1.Plot.Title("Hours per Mouth");
        }

        private void RatingViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PrintButton.IsEnabled = true;

                DateTime[] dates = GetMonthsOfYear();

                double[] dataY = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                foreach(RatingRaportData raport in ((RatingTeacherData)RatingViewList.SelectedItem).raports)
                {
                    dataY[raport.date.Month - 1] += raport.hours;
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

                    MessageBox.Show("График успешно сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
