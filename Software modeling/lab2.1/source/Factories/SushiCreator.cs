using Cafe.Products;

namespace Cafe.Factories
{
    class SushiCreator : Creator
    {
        public override CreatorProduct CreateProduct(int quantity)
        {
            return new CreatorProduct(new Sushi(), quantity);
        }
    }
}
