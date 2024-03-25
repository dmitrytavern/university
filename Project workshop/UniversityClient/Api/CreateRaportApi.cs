using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace UniversityClient.Api
{
    class CreateRaportApi
    {
        public static async Task<UniversityServer.HttpMessage> Handle(string name, string hours, string date)
        {
            using (HttpClient client = new HttpClient())
            {
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
