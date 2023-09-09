using Cafe.Products;

namespace Cafe.Factories
{
    class PastaCreator : Creator
    {
        public override CreatorProduct CreateProduct(int quantity)
        {
            return new CreatorProduct(new Pasta(), quantity);
        }
    }
}
