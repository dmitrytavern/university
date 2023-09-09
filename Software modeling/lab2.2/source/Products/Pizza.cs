namespace PizzaApp.Products
{
    abstract class Pizza
    {
        public abstract List<string> Prepare();
        public abstract List<string> Bake();
        public abstract List<string> Cut();
        public abstract List<string> Box();
    }
}
