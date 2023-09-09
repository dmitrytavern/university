namespace PizzaApp.Products
{
    class PepperoniPizza : Pizza
    {
        public override List<string> Prepare()
        {
            return new List<string>
            {
                "Preparing pepperoni pizza",
                "Adding pepperoni slices",
                "Adding cheese topping",
                "Adding tomato sauce"
            };
        }

        public override List<string> Bake()
        {
            return new List<string>
            {
                "Baking pepperoni pizza in the oven",
                "Checking for crispy crust"
            };
        }

        public override List<string> Cut()
        {
            return new List<string>
            {
                "Cutting the pepperoni pizza into slices"
            };
        }

        public override List<string> Box()
        {
            return new List<string>
            {
                "Placing the pepperoni pizza in a box"
            };
        }
    }
}
