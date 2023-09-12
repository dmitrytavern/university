using App.Interfaces;

namespace App.Entities
{
    class Director : IEmployee
    {
        public string Id { get; }

        public string Date { get; }

        public string Name { get; }

        public decimal Salary { get; }

        public Director(string name, string date)
        {
            Id = DateTime.Now.ToString();
            Date = date;
            Name = name;
            Salary = 25000;
        }

        public override string ToString()
        {
            return Name + "(Director) (" + Salary + ") (" + Date + ")";
        }
    }
}
