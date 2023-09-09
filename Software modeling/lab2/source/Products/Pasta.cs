using Cafe.Enums;
using Cafe.Interfaces;

namespace Cafe.Products
{
    class Pasta : IProduct
    {
        public int Id { get; } = (int)ProductsEnum.Pasta;

        public string Name { get; } = "Pasta";

        public double Cost { get; } = 6.50;
    }
}
