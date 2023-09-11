namespace App.Bank.Entities
{
    class Credit
    {
        public readonly int Years;

        public readonly decimal Amount;

        public Credit(int years, decimal amount)
        {
            Years = years;
            Amount = amount;
        }
    }
}
