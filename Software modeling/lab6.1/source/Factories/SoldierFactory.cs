using App.Entities;
using App.Enums;
using App.Interfaces;
using System.Diagnostics;

namespace App.Factories
{
    class SoldierFactory
    {
        public static ISoldier CreateSoldier(string name, SoldiersEnum soldier, RangsEnum rang, RanksEnum rank)
        {
            switch (soldier)
            {
                case SoldiersEnum.Infantryman:
                    return new Infantryman(name, rang, rank);
                case SoldiersEnum.Paratrooper:
                    return new Paratrooper(name, rang, rank);
                case SoldiersEnum.Artilleryman:
                    return new Artilleryman(name, rang, rank);
                default:
                    throw new Exception("Invalid soldier.");
            }
        }
    }
}
