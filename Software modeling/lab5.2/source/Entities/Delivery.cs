using App.Interfaces;

namespace App.Entities
{
    class Delivery : IDelivery
    {
        private readonly string City;
        private readonly string Country;
        private readonly string Address;
        private readonly decimal Price;

        public Delivery(string city, string country, string address, decimal price)
        {
            City = city;
            Country = country;
            Address = address;
            Price = price;
        }

        public string GetAddress()
        {
            return Country + " " + City + " " + Address;
        }

        public decimal GetAmount()
        {
            return Price;
        }
    }
}
