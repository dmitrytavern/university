using Cafe.Products;

namespace Cafe.Factories
{
    class PizzaCreator : Creator
    {
        public override CreatorProduct CreateProduct(int quantity)
        {
            return new CreatorProduct(new Pizza(), quantity);
        }
    }
}
