using App.Bank.Entities;

namespace App.Bank
{
    class CreditSubsystem
    {
        public static decimal CalculateCreditAmount(Credit credit)
        {
            return credit.Amount + (credit.Amount * (decimal)0.3 * credit.Years);
        }
    }
}
