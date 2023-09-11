using App.Entities;

namespace App.Interfaces
{
    interface IShippingService
    {
        void AddToOrder(IOrder order, string country, string city, string address);
    }
}
