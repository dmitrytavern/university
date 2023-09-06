namespace Lab2.CafeItems
{
    abstract class CafeItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public abstract double CalculatePrice();
    }
}
