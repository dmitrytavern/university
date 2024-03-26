using System.Net;
using System.Text;
using System.Text.Json;
using UniversityServer.Database;
using UniversityServer.ViewModels;

namespace UniversityServer
{
    public readonly struct HttpMessage(string message)
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
                    SendResponse(response, new { id = teacher.id, name = teacher.name, email = teacher.email, password = teacher.password, surname = teacher.surname });

                    return;
                }

                throw new Exception("Login or password incorrect.");
            }
            catch(Exception ex)
            {
                SendErrorResponse(response, ex.Message);
            }
        }

        public static void CreateRaport(HttpListenerRequest request, HttpListenerResponse response)
        {
            try
            {
                string? teacher_id = request.QueryString["teacher_id"];
                string? name = request.QueryString["name"];
                string? hours = request.QueryString["hours"];
                string? date = request.QueryString["date"];

                if (teacher_id != null)
                {
                    int parsed_teacher_id = int.Parse(teacher_id);

                    Teachers? teacher = App.db.Teachers.SingleOrDefault(teacher => teacher.id == parsed_teacher_id);

                    if (teacher != null)
                    {
                        if (String.IsNullOrWhiteSpace(name) ||
                            String.IsNullOrWhiteSpace(hours) ||
                            String.IsNullOrWhiteSpace(date))
                        {
                            throw new Exception("Data not corrent and have empty values.");
                        }

                        Raports newRaport = new Raports
                        {
                            teacher_id = parsed_teacher_id,
                            name = name,
                            hours = double.Parse(hours),
                            date = DateTime.Parse(date),
                        };

                        App.db.Raports.InsertOnSubmit(newRaport);

                        App.db.SubmitChanges();

                        SendResponse(response, new HttpMessage("Raport success created!"));

                        return;
                    }
                }

                throw new Exception("Teacher not found.");
            }
            catch(Exception ex)
            {
                SendErrorResponse(response, ex.Message);
            }
        }

        public static void GetRating(HttpListenerRequest request, HttpListenerResponse response)
        {
            try
            {
                List<RatingTeacherData> data = [];
                List<Teachers> teachers = App.db.Teachers.ToList();

                foreach (Teachers teacher in teachers)
                {
                    List<RatingRaportData> raportsData = [];
                    List<Raports> raports = App.db.Raports.Where(p => p.teacher_id == teacher.id && p.date.Year == DateTime.Today.Year).ToList();

                    double hours = 0;

                    foreach (Raports raport in raports)
                    {
                        raportsData.Add(new RatingRaportData(raport.hours, raport.date));
                        hours += raport.hours;
                    }

                    hours = Math.Round(hours, 2);

                    data.Add(new RatingTeacherData(0, teacher.name + " " + teacher.surname, hours, raportsData));
                }

                data.Sort((x, y) => y.hours.CompareTo(x.hours));

                int i = 1;
                foreach (RatingTeacherData teacherData in data)
                {
                    teacherData.number = i;
                    i++;
                }

                SendResponse(response, data);
            }
            catch (Exception ex)
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
