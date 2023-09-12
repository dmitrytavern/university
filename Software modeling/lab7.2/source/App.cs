using App.Interfaces;
using App.Subscribers;

namespace App
{
    public partial class App : Form
    {
        IAlertObservable system = new PublishAlert();
        IAlertObserver fileSubsystem = new FileAlertSubscriber("alerts.txt");
        IAlertObserver databaseSubsystem = new OracleAlertSubscriber("oracle_connection_string");

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            fileSubsystem.Updated += Subsystem_Updated;
            system.RegisterObserver(fileSubsystem);

            databaseSubsystem.Updated += Subsystem_Updated;
            system.RegisterObserver(databaseSubsystem);
        }

        private void buttonAddMessage_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxMessage.Text))
            {
                listBox1.Items.Add("Critical error: " + textBoxMessage.Text);
                system.NotifyObservers(textBoxMessage.Text);
            }
        }

        private void Subsystem_Updated(string arg1, IAlertObserver arg2)
        {
            listBox1.Items.Add(arg1);
        }
    }
}