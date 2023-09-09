using Cafe.Products;

namespace Cafe.Factories
{
    class BurgerCreator : Creator
    {
        public override CreatorProduct CreateProduct(int quantity)
        {
            return new CreatorProduct(new Burger(), quantity);
        }
    }
}
