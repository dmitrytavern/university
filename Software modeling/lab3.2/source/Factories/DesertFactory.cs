using App.Interfaces;
using App.Terrains;
using App.Vegetations;

namespace App.Factories
{
    class DesertFactory : IAbstractFactory
    {
        public IAbstractTerrain CreateTerrain()
        {
            return new SandTerrain(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
        }

        public IAbstractVegetation CreateVegetation()
        {
            return new CactusVegetation(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
        }
    }
}
