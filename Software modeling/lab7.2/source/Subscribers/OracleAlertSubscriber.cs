using App.Interfaces;

namespace App.Subscribers
{
    class OracleAlertSubscriber : IAlertObserver
    {
        public event Action<string, IAlertObserver> Updated;

        private string connectionString;

        public OracleAlertSubscriber(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Update(string alert)
        {
            Updated?.Invoke("Alert '" + alert + "' was put to oracle database by " + connectionString, this);
        }
    }
}
