namespace PizzaApp.Products
{
    class ClamPizza : Pizza
    {
        public override List<string> Prepare()
        {
            return new List<string>
            {
                "Preparing seafood pizza",
                "Adding a mix of seafood (such as clams, mussels, and shrimp)",
                "Adding cheese topping",
                "Adding tomato sauce with a hint of garlic"
            };
        }

        public override List<string> Bake()
        {
            return new List<string>
            {
                "Baking seafood pizza in the oven",
                "Checking for a golden and bubbling crust"
            };
        }

        public override List<string> Cut()
        {
            return new List<string>
            {
                "Cutting the seafood pizza into slices"
            };
        }

        public override List<string> Box()
        {
            return new List<string>
            {
                "Placing the seafood pizza in a box"
            };
        }
    }
}
