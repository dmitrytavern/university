using App.Interfaces;

namespace App.Strategies
{
    class ExpressStrategy : IStrategy
    {
        public void Calculate(IOrder order)
        {
            order.SetDeliveryPrice(44.0);
        }
    }
}
