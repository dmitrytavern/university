namespace TestUniversity
{
    public class AuthTest
    {
        [Fact]
        public async void ShouldAuthWithError()
        {
            UniversityServer.App.StartServer();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/login?email=nobody&password=nobody");

                Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest, "Login API must return Bad request");
            }

            UniversityServer.App.StopServer();
        }

        [Fact]
        public async void ShouldAuthSuccess()
        {
            UniversityServer.App.StartServer();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/login?email=jack.rassel@gmail.com&password=help");

                Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK, "Login API must return success status");
            }

            UniversityServer.App.StopServer();
        }
    }
}