using System.Net.Http;
using System.Windows;

namespace UniversityClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectButton.IsEnabled = false;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://localhost:8080");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    StatusTextBlock.Text = "Current status: Online\nResponse: " + responseBody;
                }
                catch (HttpRequestException ex)
                {
                    StatusTextBlock.Text = "Current status: Error\nResponse: " + ex.Message;
                }
                finally
                {
                    ConnectButton.IsEnabled = true;
                }
            }
        }
    }
}