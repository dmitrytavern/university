using App.Interfaces;

namespace App.Vegetations
{
    class TreeVegetation : IAbstractVegetation
    {
        private readonly string _id;

        public TreeVegetation(string id)
        {
            _id = id;
        }

        public string GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return "Tree";
        }
    }
}
