namespace PizzaApp.Products
{
    class VeggiePizza : Pizza
    {
        public override List<string> Prepare()
        {
            return new List<string>
            {
                "Preparing vegan pizza",
                "Rolling out a vegan dough",
                "Adding a variety of fresh vegetables (such as bell peppers, onions, and mushrooms)",
                "Drizzling with olive oil",
                "Sprinkling with vegan cheese or nutritional yeast",
                "Adding a tomato sauce without animal products"
            };
        }

        public override List<string> Bake()
        {
            return new List<string>
            {
                "Baking vegan pizza in the oven",
                "Checking for a golden and crispy crust"
            };
        }

        public override List<string> Cut()
        {
            return new List<string>
            {
                "Cutting the vegan pizza into slices"
            };
        }

        public override List<string> Box()
        {
            return new List<string>
            {
                "Placing the vegan pizza in a vegan-friendly box"
            };
        }
    }
}
