using App.Entities;
using App.Enums;
using App.Interfaces;

namespace App.Facades
{
    class FoodDeliveryFacade : IFacade
    {
        private IOrder? order;
        private readonly IRestaurant restaurant;
        private readonly IShippingService shippingService;

        public FoodDeliveryFacade(IRestaurant restaurant, IShippingService shippingService)
        {
            this.restaurant = restaurant;
            this.shippingService = shippingService;
        }

        public void CreateOrder()
        {
            order = new Order();
        }

        public void AddAddress(string country, string city, string address)
        {
            if (order == null)
            {
                throw new Exception("Order not created.");
            }

            shippingService.AddToOrder(order, country, city, address);
        }

        public void AddProduct(ProductsEnum product)
        {
            if (order == null)
            {
                throw new Exception("Order not created.");
            }

            restaurant.AddToOrder(order, product);
        }

        public IOrder ComfirmOrder()
        {
            if (order == null)
            {
                throw new Exception("Order not created.");
            }

            return order;
        }
    }
}
