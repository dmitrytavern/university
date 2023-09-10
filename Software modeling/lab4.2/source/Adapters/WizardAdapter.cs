using App.Fighters;
using App.Interfaces;

namespace App.Adapters
{
    class WizardAdapter : IFighter
    {
        private readonly Wizard wizard;

        public WizardAdapter(Wizard wizard)
        {
            this.wizard = wizard;
        }

        public void Attack()
        {
            wizard.CastDestructionSpell();
        }

        public void Defend()
        {
            wizard.UseShield();
        }

        public void Escape()
        {
            wizard.UsePortal();
        }
    }
}
