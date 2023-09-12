using App.Interfaces;

namespace App.Entities
{
    class Manager : IEmployee
    {
        public string Id { get; }

        public string Date { get; }

        public string Name { get; }

        public decimal Salary { get; }

        public Manager(string name, string date)
        {
            Id = DateTime.Now.ToString();
            Date = date;
            Name = name;
            Salary = 17000;
        }

        public override string ToString()
        {
            return Name + "(Manager) (" + Salary + ") (" + Date + ")";
        }
    }
}
