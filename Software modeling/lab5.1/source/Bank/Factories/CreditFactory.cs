using App.Bank.Entities;

namespace App.Bank.Factories
{
    class CreditFactory
    {
        public static Credit CreateCredit(int years, decimal amount)
        {
            return new Credit(years, amount);
        }
    }
}
