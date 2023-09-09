using Cafe.Enums;
using Cafe.Interfaces;

namespace Cafe.Products
{
    class Burger : IProduct
    {
        public int Id { get; } = (int)ProductsEnum.Burger;

        public string Name { get; } = "Burger";

        public double Cost { get; } = 12.12;
    }
}
