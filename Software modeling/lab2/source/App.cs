using Cafe.Enums;
using Cafe.Factories;

namespace Cafe
{
    public partial class App : Form
    {
        private readonly List<CreatorProduct> order = new();

        public App()
        {
            InitializeComponent();
            comboBoxProducts.Items.Add(ProductsEnum.Sushi);
            comboBoxProducts.Items.Add(ProductsEnum.Pasta);
            comboBoxProducts.Items.Add(ProductsEnum.Pancake);
            comboBoxProducts.Items.Add(ProductsEnum.Pizza);
            comboBoxProducts.Items.Add(ProductsEnum.Burger);
            comboBoxProducts.SelectedIndex = 0;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedItem != null)
            {
                Creator creator;

                switch((int)comboBoxProducts.SelectedItem)
                {
                    case (int)ProductsEnum.Sushi:
                        {
                            creator = new SushiCreator();
                            break;
                        }
                    case (int)ProductsEnum.Pasta:
                        {
                            creator = new PastaCreator();
                            break;
                        }
                    case (int)ProductsEnum.Pancake:
                        {
                            creator = new PancakeCreator();
                            break;
                        }
                    case (int)ProductsEnum.Pizza:
                        {
                            creator = new PizzaCreator();
                            break;
                        }
                    case (int)ProductsEnum.Burger:
                        {
                            creator = new BurgerCreator();
                            break;
                        }
                    default:
                        throw new Exception("Invalid product id.");
                }

                AddProduct(creator, (int)numericProductQuantity.Value);
            }
        }

        private void AddProduct(Creator creator, int quantity)
        {
            CreatorProduct product = creator.CreateProduct(quantity);

            order.Add(product);

            listBoxOrder.Items.Add(
                product.Product.Name +
                " x" +
                product.Quantity +
                " - " +
                Math.Round(product.Quantity * product.Product.Cost, 2)
            );
        }

        private void buttonCalculateOrder_Click(object sender, EventArgs e)
        {
            double totalCost = 0;

            foreach (CreatorProduct product in order)
            {
                totalCost += Math.Round(product.Quantity * product.Product.Cost, 2);
            }

            labelTotalPrice.Text = "$" + Math.Round(totalCost, 2);
        }

        private void buttonClearOrder_Click(object sender, EventArgs e)
        {
            order.Clear();
            listBoxOrder.Items.Clear();
            labelTotalPrice.Text = "$0";
        }
    }
}
