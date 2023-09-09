using Cafe.Products;

namespace Cafe.Factories
{
    class PancakeCreator : Creator
    {
        public override CreatorProduct CreateProduct(int quantity)
        {
            return new CreatorProduct(new Pancake(), quantity);
        }
    }
}
