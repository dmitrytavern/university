using App.Enums;

namespace App.Interfaces
{
    interface ISoldier
    {
        public string Id { get; }

        public string Name { get; }

        public SoldiersEnum Group { get; }

        public RangsEnum Rang { get; }

        public RanksEnum Rank { get; }
    }
}
