namespace App.Fighters
{
    class Dragon
    {
        private readonly App app;

        public Dragon(App app)
        {
            this.app = app;
        }

        public void BreatheFire()
        {
            app.CreateLog("The dragon attacked with his breath");
        }

        public void FlapWings()
        {
            app.CreateLog("The dragon defended himself with his wings");
        }

        public void FlyAway()
        {
            app.CreateLog("The dragon flew away");
        }
    }
}
