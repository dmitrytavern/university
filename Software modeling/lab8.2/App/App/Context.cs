using App.Interfaces;

namespace App
{
    internal class Context
    {
        private IStrategy? _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteTactic(IFighter fighter)
        {

            if (_strategy is null)
            {
                throw new Exception("Strategy is null.");
            }

            _strategy.ExecuteTactic(fighter);
        }
    }
}
