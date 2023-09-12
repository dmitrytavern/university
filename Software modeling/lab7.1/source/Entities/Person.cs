using App.Enums;
using App.Interfaces;

namespace App.Entities
{
    class Person : IPerson
    {
        public event Action<string, Person> Updated;

        public string Name { get; }

        public VacanciesEnum DesiredPosition { get; }

        public Person(string name, VacanciesEnum desiredPosition)
        {
            Name = name;
            DesiredPosition = desiredPosition;
        }

        public void Update(VacanciesEnum vacancy)
        {
            if (DesiredPosition == vacancy)
            {
                Updated?.Invoke(Name + " interested in a job", this);
            }
        }
    }
}
