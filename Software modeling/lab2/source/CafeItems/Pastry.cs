namespace Lab2.CafeItems
{
    class Pastry : CafeItem
    {
        public Pastry(int quantity)
        {
            Name = "Pastry";
            Price = 2.99;
            Quantity = quantity;
        }

        public override double CalculatePrice()
        {
            return Price * Quantity;
        }
    }
}
