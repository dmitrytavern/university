namespace App.Interfaces
{
    interface IAbstractFactory
    {
        public IAbstractTerrain CreateTerrain();

        public IAbstractVegetation CreateVegetation();
    }
}
