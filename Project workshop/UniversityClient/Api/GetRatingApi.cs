using System.Net.Http;
using System.Text.Json;
using UniversityServer.ViewModels;

namespace UniversityClient.Api
{
    /// <summary>
    /// Provides functionality for fetching rating data from the API.
    /// </summary>
    class GetRatingApi
    {
        /// <summary>
        /// Handles the request to fetch rating data asynchronously.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation with the list of RatingTeacherData objects.</returns>
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