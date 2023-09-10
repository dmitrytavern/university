using App.Fighters;
using App.Interfaces;

namespace App.Adapters
{
    class DragonAdapter : IFighter
    {
        private readonly Dragon dragon;

        public DragonAdapter(Dragon dragon)
        {
            this.dragon = dragon;
        }

        public void Attack()
        {
            dragon.BreatheFire();
        }

        public void Defend()
        {
            dragon.FlapWings();
        }

        public void Escape()
        {
            dragon.FlyAway();
        }
    }
}
