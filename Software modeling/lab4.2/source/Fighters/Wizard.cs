namespace App.Fighters
{
    class Wizard
    {
        private readonly App app;

        public Wizard(App app)
        {
            this.app = app;
        }

        public void CastDestructionSpell()
        {
            app.CreateLog("Wizard attack and cast destruction spell");
        }

        public void UseShield()
        {
            app.CreateLog("Wizard used shield");
        }

        public void UsePortal()
        {
            app.CreateLog("Wizard used portal and escape from game");
        }
    }
}
