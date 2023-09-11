using App.Enums;
using App.Interfaces;

namespace App.Entities
{
    class Paratrooper : ISoldier
    {
        public string Id { get; }

        public string Name { get; }

        public SoldiersEnum Group { get; }

        public RangsEnum Rang { get; }

        public RanksEnum Rank { get; }

        public Paratrooper(string name, RangsEnum rang, RanksEnum rank)
        {
            Id = DateTime.Now.ToString();
            Name = name;
            Group = SoldiersEnum.Paratrooper;
            Rang = rang;
            Rank = rank;
        }
    }
}
