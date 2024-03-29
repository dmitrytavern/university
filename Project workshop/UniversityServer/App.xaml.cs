using System.Net;
using System.Text;
using System.Windows;
using UniversityServer.Database;

namespace UniversityServer
{

    public partial class App : Application
    {
        public static readonly Thread serverThread;
        public static readonly HttpListener serverListener;

        public static DataClassesDataContext? db;

        public static string _DBName = "University";
        public static string DBName
        {
            get { return _DBName; }
            set { _DBName = value; }
        }

        public static string _DBSource = "DESKTOP-4EQTI1O";
        public static string DBSource
        {
            get { return _DBSource; }
            set { _DBSource = value; }
        }

        private static string _ServerPort = "8080";
        public static string ServerPort {
            get { return _ServerPort; }
            set { _ServerPort = value;  }
        }

        private static bool _ServerActive = false;
        public static bool ServerActive
        {
            get { return _ServerActive; }
            set { _ServerActive = value; }
        }

        private static bool _AppActive = true;
        public static bool AppActive
        {
            get { return _AppActive; }
            set { _AppActive = value; }
        }

        static App()
        {
            serverThread = new Thread(ServerThreadListener);
            serverListener = new HttpListener();
            serverThread.Start();
        }

        public static void ConnectDatabase()
        {
            db = new DataClassesDataContext(@"Data Source=" + DBSource + ";Initial Catalog=" + DBName + ";Integrated Security=True");

            if (db.DatabaseExists() == false)
            {
                db.CreateDatabase();
            }
        }

        public static void StartServer()
        {
            serverListener.Prefixes.Add("http://localhost:" + ServerPort + "/");
            serverListener.Start();
            ServerActive = true;
        }

        public static void StopServer()
        {
            ServerActive = false;
            serverListener.Stop();
            serverListener.Prefixes.Clear();
        }

        protected static void OnServerListener()
        {
            try
            {
                if (ServerActive)
                {
                    HttpListenerContext context = serverListener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    switch(request.Url?.AbsolutePath)
                    {
                        case "/login":
                            AppRouter.Login(request, response);
                            return;
                        case "/create":
                            AppRouter.CreateRaport(request, response);
                            return;
                        case "/rating":
                            AppRouter.GetRating(request, response);
                            return;
                    }

                    byte[] buffer = Encoding.UTF8.GetBytes("Hello my client!");

                    response.ContentType = "text/plain";
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
            }
            catch (Exception) { }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            StopServer();
            AppActive = false;
            serverThread.Join();
        }

        protected static void ServerThreadListener()
        {
            while (AppActive)
            {
                OnServerListener();
            }
        }
    }
}
