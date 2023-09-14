using App.Enums;
using App.Interfaces;

namespace App.Entities
{
    class Infantryman : ISoldier
    {
        public string Id { get; }

        public string Name { get; }

        public SoldiersEnum Group { get; }

        public RangsEnum Rang { get; }

        public RanksEnum Rank { get; }

        public Infantryman(string name, RangsEnum rang, RanksEnum rank)
        {
            Id = DateTime.Now.ToString();
            Name = name;
            Group = SoldiersEnum.Infantryman;
            Rang = rang;
            Rank = rank;
        }

        public override string ToString()
        {
            return Name + " (" + Group + " " + Rang + " " + Rank + ")";
        }
    }
}
