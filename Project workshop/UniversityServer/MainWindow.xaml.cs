using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using UniversityServer.Components;

namespace UniversityServer
{
   public partial class MainWindow : Window
    {
        private static HttpListener? listener;
        private static Thread? serverThread;
        public static bool ServerActive = false;
        public static string ServerPort = "8080";

        public MainWindow()
        {
            InitializeComponent();
        }

        public static void StartServer()
        {
            string url = "http://localhost:" + ServerPort + "/";

            Console.Write(url);

            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();

            serverThread = new Thread(ServerListener);
            serverThread.Start();

            ServerActive = true;
        }

        public static void StopServer()
        {
            ServerActive = false;
            listener?.Stop();
            serverThread?.Join();
            listener = null;
            serverThread = null;
        }

        private static void ServerListener()
        {
            try
            {
                while (listener != null && listener.IsListening)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    byte[] buffer = Encoding.UTF8.GetBytes("Hello my client!");

                    response.ContentType = "text/plain";
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
            } catch(Exception ex)
            {}
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listener?.Stop();
            serverThread?.Join();
        }

        private void Sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationButton? selected = sidebar.SelectedItem as NavigationButton;

            if (selected != null && navframe != null)
            {
                navframe.Navigate(selected.Navlink);
            }
        }
    }
}