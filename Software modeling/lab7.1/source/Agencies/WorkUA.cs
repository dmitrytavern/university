using App.Enums;
using App.Interfaces;

namespace App.Agencies
{
    class WorkUA : IAgency
    {
        private readonly List<IObserver> observers = new();
        private readonly List<VacanciesEnum> vacancies = new();

        public string Name { get; } = "Work.ua";

        public List<VacanciesEnum> GetVacancies()
        {
            return vacancies;
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void AddVacancy(VacanciesEnum vacancy)
        {
            vacancies.Add(vacancy);

            NotifyObservers(vacancy);
        }

        private void NotifyObservers(VacanciesEnum vacancy)
        {
            foreach (var observer in observers)
            {
                observer.Update(vacancy);
            }
        }
    }
}
