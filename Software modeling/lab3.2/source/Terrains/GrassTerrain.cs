using App.Interfaces;

namespace App.Terrains
{
    class GrassTerrain : IAbstractTerrain
    {
        private readonly string _id;

        public GrassTerrain(string id)
        {
            _id = id;
        }

        public string GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return "Grass";
        }
    }
}
