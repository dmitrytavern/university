using App.Bank.Entities;

namespace App.Bank
{
    class MortgageFacade
    {
        public bool TakeCredit(Customer customer, Credit credit)
        {
            decimal creditAmount = CreditSubsystem.CalculateCreditAmount(credit);

            return BankingSubsystem.CheckSolvency(customer, credit, creditAmount);
        }
    }
}
