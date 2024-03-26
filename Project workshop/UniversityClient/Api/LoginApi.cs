using System.Net.Http;
using System.Text.Json;

namespace UniversityClient.Api
{
    /// <summary>
    /// Provides functionality for handling login API requests.
    /// </summary>
    class LoginApi
    {
        /// <summary>
        /// Handles the login request asynchronously.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A Task representing the asynchronous operation with the TeacherData object.</returns>
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
