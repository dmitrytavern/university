namespace App.Bank.Entities
{
    class Customer
    {
        public readonly string Id;
        public readonly string Name;
        public readonly decimal Earnings;

        public Customer(string id, string name, decimal earnings)
        {
            Id = id;
            Name = name;
            Earnings = earnings;
        }
    }
}
