using App.Enums;

namespace App.Interfaces
{
    interface IAgency
    {
        string Name { get; }

        List<VacanciesEnum> GetVacancies();

        void AddObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void AddVacancy(VacanciesEnum vacancy);
    }
}
