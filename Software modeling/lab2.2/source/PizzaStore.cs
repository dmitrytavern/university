using PizzaApp.Facotries;
using PizzaApp.Products;

namespace PizzaApp
{
    class PizzaStore
    {
        public static Pizza OrderPizza(int productId)
        {
            return PizzaFactory.CreatePizza(productId);
        }
    }
}
