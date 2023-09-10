using App.Interfaces;
using App.Terrains;
using App.Vegetations;

namespace App.Factories
{
    class ForestFactory : IAbstractFactory
    {
        public IAbstractTerrain CreateTerrain()
        {
            return new GrassTerrain(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
        }

        public IAbstractVegetation CreateVegetation()
        {
            return new TreeVegetation(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
        }
    }
}
