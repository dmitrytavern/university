using App.Interfaces;

namespace App.Entities
{
    class Order : IOrder
    {
        public string Name { get; }

        public double Price { get; }

        public double DeliveryPrice { get; set; } = 0.0;

        public Order(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public double GetTotal()
        {
            return Price + DeliveryPrice ;
        }

        public void SetDeliveryPrice(double price)
        {
            DeliveryPrice = price;
        }
    }
}
