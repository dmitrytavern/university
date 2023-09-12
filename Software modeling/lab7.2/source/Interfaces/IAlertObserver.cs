namespace App.Interfaces
{
    interface IAlertObserver
    {
        event Action<string, IAlertObserver> Updated;

        void Update(string alert);
    }
}
