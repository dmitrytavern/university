using App.Interfaces;

namespace App.Entities
{
    class Worker : IEmployee
    {
        public string Id { get; }

        public string Date { get; }

        public string Name { get; }

        public decimal Salary { get; }

        public Worker(string name, string date)
        {
            Id = DateTime.Now.ToString();
            Date = date;
            Name = name;
            Salary = 6500;
        }

        public override string ToString()
        {
            return Name + "(Worker) (" + Salary + ") (" + Date + ")";
        }
    }
}
