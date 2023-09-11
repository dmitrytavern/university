using App.Interfaces;

namespace App.Entities.Products
{
    class Burger : IProduct
    {
        public string Id { get; }

        public string Name { get; }

        public decimal Cost { get; }

        public Burger()
        {
            Id = DateTime.Now.ToString();
            Name = "Burger";
            Cost = (decimal)24.50;
        }
    }
}
