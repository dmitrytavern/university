using PizzaApp.Enums;
using PizzaApp.Products;

namespace PizzaApp.Facotries
{
    class PizzaFactory
    {
        public static Pizza CreatePizza(int pizzaId)
        {
            switch(pizzaId)
            {
                case (int)ProductsEnum.CheesePizza:
                    return new CheesePizza();
                case (int)ProductsEnum.ClamPizza:
                    return new ClamPizza();
                case (int)ProductsEnum.PepperoniPizza:
                    return new PepperoniPizza();
                case (int)ProductsEnum.VeggiePizza:
                    return new VeggiePizza();
                default:
                    throw new Exception("Pizza by id not found: " + pizzaId);
            }
        }
    }
}
