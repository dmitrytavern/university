using Cafe.Enums;
using Cafe.Interfaces;

namespace Cafe.Products
{
    class Pancake : IProduct
    {
        public int Id { get; } = (int)ProductsEnum.Pancake;

        public string Name { get; } = "Pancake";

        public double Cost { get; } = 14.35;
    }
}
