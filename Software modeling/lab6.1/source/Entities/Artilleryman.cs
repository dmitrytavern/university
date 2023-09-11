using App.Enums;
using App.Interfaces;

namespace App.Entities
{
    class Artilleryman : ISoldier
    {
        public string Id { get; }

        public string Name { get; }

        public SoldiersEnum Group { get; }

        public RangsEnum Rang { get; }

        public RanksEnum Rank { get; }

        public Artilleryman(string name, RangsEnum rang, RanksEnum rank)
        {
            Id = DateTime.Now.ToString();
            Name = name;
            Group = SoldiersEnum.Artilleryman;
            Rang = rang;
            Rank = rank;
        }
    }
}
