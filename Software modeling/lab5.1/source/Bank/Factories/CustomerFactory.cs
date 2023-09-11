using App.Bank.Entities;

namespace App.Bank.Factories
{
    class CustomerFactory
    {
        public static Customer CreateCustomer(string firstname, string lastname, decimal earnings)
        {
            return new Customer(
                DateTime.Now.ToString(),
                firstname + " " + lastname,
                earnings
            );
        }
    }
}
