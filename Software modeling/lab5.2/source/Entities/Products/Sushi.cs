using App.Interfaces;

namespace App.Entities.Products
{
    class Sushi : IProduct
    {
        public string Id { get; }

        public string Name { get; }

        public decimal Cost { get; }

        public Sushi()
        {
            Id = DateTime.Now.ToString();
            Name = "Sushi";
            Cost = (decimal)12.75;
        }
    }
}
