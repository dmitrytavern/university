namespace Lab2.CafeItems
{
    class Pancake : CafeItem
    {
        public Pancake(int quantity)
        {
            Name = "Pancake";
            Price = 12.99;
            Quantity = quantity;
        }

        public override double CalculatePrice()
        {
            return Price * Quantity;
        }
    }
}
