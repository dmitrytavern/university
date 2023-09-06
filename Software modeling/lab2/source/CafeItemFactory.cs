using Lab2.CafeItems;

namespace Lab2
{
    class CafeItemFactory
    {
        public CafeItem CreateCafeItem(int itemIndex, int quantity)
        {
            switch (itemIndex)
            {
                case 1:
                    return new IceCream(quantity);
                case 2:
                    return new Pancake(quantity);
                case 3:
                    return new Pastry(quantity);
                default:
                    throw new ArgumentException("Cafe item not found.");
            }
        }
    }
}
