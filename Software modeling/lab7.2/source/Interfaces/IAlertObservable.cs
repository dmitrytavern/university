namespace App.Interfaces
{
    interface IAlertObservable
    {
        void RegisterObserver(IAlertObserver observer);
        void UnregisterObserver(IAlertObserver observer);
        void NotifyObservers(string alert);
    }
}
