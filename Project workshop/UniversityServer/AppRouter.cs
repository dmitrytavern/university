using System.Net;
using System.Text;
using System.Text.Json;
using UniversityServer.Database;

namespace UniversityServer
{
    readonly struct HttpMessage(string message)
    {
        public readonly string message { get; } = message;
    }

    class AppRouter
    {
        public static void Login(HttpListenerRequest request, HttpListenerResponse response)
        {
            try
            {
                string? email = request.QueryString["email"];
                string? password = request.QueryString["password"];

                Teachers? teacher = App.db.Teachers.SingleOrDefault(teacher => teacher.email == email && teacher.password == password);

                if (teacher != null)
                {
                    SendResponse(response, teacher);

                    return;
                }

                throw new Exception("Login or password incorrect.");
            }
            catch(Exception ex)
            {
                SendErrorResponse(response, ex.Message);
            }
        }

        private static void SendResponse(HttpListenerResponse response, object responseData)
        {
            response.StatusCode = (int)HttpStatusCode.OK;
            response.ContentType = "application/json";
            byte[] buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(responseData));
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }

        private static void SendErrorResponse(HttpListenerResponse response, string errorMessage)
        {
            HttpMessage message = new(errorMessage);

            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ContentType = "application/json";
            byte[] buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }
}
