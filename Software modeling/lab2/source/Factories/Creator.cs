using Cafe.Interfaces;

namespace Cafe.Factories
{
    abstract class Creator
    {
        public abstract CreatorProduct CreateProduct(int quantity);
    }

    class CreatorProduct
    {
        public IProduct Product { get; }
        public int Quantity { get; }

        public CreatorProduct(IProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
