using App.Interfaces;

namespace App.Strategies
{
    class StandartStrategy : IStrategy
    {
        public void Calculate(IOrder order)
        {
            order.SetDeliveryPrice(23.0);
        }
    }
}
