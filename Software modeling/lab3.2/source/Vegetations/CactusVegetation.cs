using App.Interfaces;

namespace App.Vegetations
{
    class CactusVegetation : IAbstractVegetation
    {
        private readonly string _id;

        public CactusVegetation(string id)
        {
            _id = id;
        }

        public string GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return "Cactus";
        }
    }
}
