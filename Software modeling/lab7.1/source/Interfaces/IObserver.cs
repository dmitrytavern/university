using App.Enums;

namespace App.Interfaces
{
    interface IObserver
    {
        void Update(VacanciesEnum vacancy);
    }
}
