namespace App.Interfaces
{
    interface IEmployee
    {
        string Id { get; }

        string Date { get; }

        string Name { get; }

        decimal Salary { get; }
    }
}
