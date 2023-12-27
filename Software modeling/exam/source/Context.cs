using App.Interfaces;

namespace App
{
    class Context
    {
        private IStrategy? _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void CalculatePrice(IOrder order)
        {

            if (_strategy is null)
            {
                throw new Exception("Strategy is null.");
            }

            _strategy.Calculate(order);
        }
    }
}
