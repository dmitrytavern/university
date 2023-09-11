using App.Enums;
using App.Facades;
using App.Interfaces;
using App.Restaurants;
using App.Shipping;

namespace App
{
    public partial class App : Form
    {
        private readonly IFacade foodDelivery;
        private readonly IRestaurant restaurant = new OnlineRestaurant();
        private readonly IShippingService shippingService = new ShippingService();

        public App()
        {
            InitializeComponent();

            foodDelivery = new FoodDeliveryFacade(restaurant, shippingService);
        }

        private void App_Load(object sender, EventArgs e)
        {
            foodDelivery.CreateOrder();
            comboBoxProduct.Items.Clear();
            comboBoxProduct.Items.Add(ProductsEnum.Burger);
            comboBoxProduct.Items.Add(ProductsEnum.Sushi);
            comboBoxCountry.SelectedIndex = 0;
            comboBoxProduct.SelectedIndex = 0;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            foodDelivery.AddProduct((ProductsEnum)comboBoxProduct.SelectedItem);
            listBoxOrder.Items.Add(comboBoxProduct.SelectedItem);
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            foodDelivery.AddAddress(
                (string)comboBoxCountry.SelectedItem,
                textBoxCity.Text,
                textBoxAddress.Text
            );

            IOrder order = foodDelivery.ComfirmOrder();

            labelResult.Text = "Your price: $" + order.GetTotal().ToString();
            labelResultAddress.Text = "Your address: " + order.GetDelivery().GetAddress();
        }
    }
}