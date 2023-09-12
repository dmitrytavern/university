using App.Interfaces;

namespace App
{
    class PublishAlert : IAlertObservable
    {
        private readonly List<IAlertObserver> alertObservers = new();

        public void RegisterObserver(IAlertObserver observer)
        {
            alertObservers.Add(observer);
        }

        public void UnregisterObserver(IAlertObserver observer)
        {
            alertObservers.Remove(observer);
        }

        public void NotifyObservers(string alert)
        {
            foreach (var observer in alertObservers)
            {
                observer.Update(alert);
            }
        }
    }
}
