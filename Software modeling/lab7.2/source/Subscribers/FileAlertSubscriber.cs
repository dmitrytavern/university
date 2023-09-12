using App.Interfaces;

namespace App.Subscribers
{
    class FileAlertSubscriber : IAlertObserver
    {
        public event Action<string, IAlertObserver> Updated;

        private string filePath;

        public FileAlertSubscriber(string filePath)
        {
            this.filePath = filePath;
        }

        public void Update(string alert)
        {
            Updated?.Invoke("Alert '" + alert + "' was writed to file: " + filePath, this);
        }
    }
}
