using Cafe.Enums;
using Cafe.Interfaces;

namespace Cafe.Products
{
    class Pizza : IProduct
    {
        public int Id { get; } = (int)ProductsEnum.Pizza;

        public string Name { get; } = "Pizza";

        public double Cost { get; } = 44.75;
    }
}
