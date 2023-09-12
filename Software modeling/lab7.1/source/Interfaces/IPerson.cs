using App.Entities;
using App.Enums;

namespace App.Interfaces
{
    interface IPerson : IObserver
    {
        public event Action<string, Person> Updated;

        public string Name { get; }

        public VacanciesEnum DesiredPosition { get; }
    }
}
