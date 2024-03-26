using System.Net.Http;
using System.Text.Json;
using UniversityServer.ViewModels;

namespace UniversityClient.Api
{
    class GetRatingApi
    {
        public static async Task<List<RatingTeacherData>> Handle()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(App.ApiUrl + "/rating");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                List<RatingTeacherData>? data = JsonSerializer.Deserialize<List<RatingTeacherData>>(responseBody);

                if (data != null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("Rating is null");
                }
            }
        }
    }
}
