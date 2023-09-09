using Cafe.Enums;
using Cafe.Interfaces;

namespace Cafe.Products
{
    class Sushi : IProduct
    {
        public int Id { get; } = (int)ProductsEnum.Sushi;

        public string Name { get; } = "Sushi";

        public double Cost { get; } = 65.99;
    }
}
