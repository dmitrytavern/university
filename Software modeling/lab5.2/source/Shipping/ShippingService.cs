using App.Entities;
using App.Interfaces;

namespace App.Shipping
{
    class ShippingService : IShippingService
    {
        public void AddToOrder(IOrder order, string country, string city, string address)
        {
            decimal deliveryPrice = 15;
            if (country == "Ukraine") deliveryPrice = 10;
            if (country == "USA") deliveryPrice = 24;

            order.SetDelivery(new Delivery(city, country, address, deliveryPrice));
        }
    }
}
