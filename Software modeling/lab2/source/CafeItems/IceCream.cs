namespace Lab2.CafeItems
{
    class IceCream : CafeItem
    {
        public IceCream(int quantity)
        {
            Name = "Ice Cream";
            Price = 5.99;
            Quantity = quantity;
        }

        public override double CalculatePrice()
        {
            return Price * Quantity;
        }
    }
}
