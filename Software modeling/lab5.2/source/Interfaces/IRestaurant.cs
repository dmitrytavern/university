using App.Enums;

namespace App.Interfaces
{
    interface IRestaurant
    {
        public void AddToOrder(IOrder order, ProductsEnum product);
    }
}
