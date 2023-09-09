namespace PizzaApp.Products
{
    class CheesePizza : Pizza
    {
        public override List<string> Prepare()
        {
            return new List<string>
            {
                "Preparing cheese pizza",
                "Adding cheese topping",
                "Adding tomato sauce"
            };
        }

        public override List<string> Bake()
        {
            return new List<string>
            {
                "Baking cheese pizza in the oven",
                "Checking for golden crust"
            };
        }

        public override List<string> Cut()
        {
            return new List<string>
            {
                "Cutting the cheese pizza into slices"
            };
        }

        public override List<string> Box()
        {
            return new List<string>
            {
                "Placing the cheese pizza in a box"
            };
        }
    }
}
