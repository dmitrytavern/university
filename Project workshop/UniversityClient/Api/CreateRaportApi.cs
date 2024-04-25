using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace UniversityClient.Api
{
    /// <summary>
    /// Provides functionality for creating a report via API.
    /// </summary>
    class CreateRaportApi
    {
        /// <summary>
        /// Handles the request to create a report asynchronously.
        /// </summary>
        /// <param name="name">The name of the report.</param>
        /// <param name="hours">The hours of the report.</param>
        /// <param name="date">The date of the report.</param>
        /// <returns>A Task representing the asynchronous operation with the HttpMessage object.</returns>
        public static async Task<UniversityServer.HttpMessage> Handle(string name, string hours, string date)
        {
            using (HttpClient client = new HttpClient())
            {
                MessageBox.Show(App.ApiUrl
                    + "/create?teacher_id=" + App.CurrentUser?.id
                    + "&name=" + name
                    + "&hours=" + hours
                    + "&date=" + date);

                HttpResponseMessage response = await client.GetAsync(App.ApiUrl
                    + "/create?teacher_id=" + App.CurrentUser?.id
                    + "&name=" + name
                    + "&hours=" + hours
                    + "&date=" + date);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<UniversityServer.HttpMessage>(responseBody);
            }
        }
    }
}
