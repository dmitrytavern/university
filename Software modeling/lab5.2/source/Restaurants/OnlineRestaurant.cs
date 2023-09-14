using App.Entities.Products;
using App.Enums;
using App.Interfaces;

namespace App.Restaurants
{
    class OnlineRestaurant : IRestaurant
    {
        public void AddToOrder(IOrder order, ProductsEnum product)
        {
            switch (product)
            {
                case ProductsEnum.Burger:
                    order.AddProduct(new Burger());
                    break;
                case ProductsEnum.Sushi:
                    order.AddProduct(new Sushi());
                    break;
                default:
                    throw new Exception("Product is invalid.");
            }
        }
    }
}
