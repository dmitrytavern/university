using App.Bank.Entities;

namespace App.Bank
{
    class BankingSubsystem
    {
        public static bool CheckSolvency(Customer customer, Credit credit, decimal creditAmount)
        {
            return creditAmount < credit.Years * (customer.Earnings * (decimal)0.75);
        }
    }
}
