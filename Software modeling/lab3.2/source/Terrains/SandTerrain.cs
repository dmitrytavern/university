using App.Interfaces;

namespace App.Terrains
{
    class SandTerrain : IAbstractTerrain
    {
        private readonly string _id;

        public SandTerrain(string id)
        {
            _id = id;
        }

        public string GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return "Sand";
        }
    }
}
