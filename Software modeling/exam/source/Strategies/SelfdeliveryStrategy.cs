using App.Interfaces;

namespace App.Strategies
{
    class SelfdeliveryStrategy : IStrategy
    {
        public void Calculate(IOrder order)
        {
            order.SetDeliveryPrice(0);
        }
    }
}
