using System.Net.Http;
using System.Text.Json;
using System.Windows;
using UniversityServer.Database;

namespace UniversityClient.Api
{
    class LoginApi
    {
        public static async Task<TeacherData> Handle(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(App.ApiUrl + "/login?email=" + email + "&password=" + password);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                TeacherData? teacher = JsonSerializer.Deserialize<TeacherData>(responseBody);

                if (teacher != null)
                {
                    return teacher;
                }
                else
                {
                    throw new Exception("Teacher is null");
                }
            }
        }
    }
}
