using App.Interfaces;

namespace App.Entities
{
    class Order : IOrder
    {
        private decimal price = 0;
        private IDelivery? delivery;
        private readonly List<IProduct> products = new();

        public void AddProduct(IProduct product)
        {
            price += product.Cost;
            products.Add(product);
        }

        public void SetDelivery(IDelivery _delivery)
        {
            delivery = _delivery;
        }

        public decimal GetTotal()
        {
            return delivery == null ? price : price + delivery.GetAmount();
        }

        public IDelivery GetDelivery()
        {
            if (delivery == null)
            {
                throw new Exception("Delivery not setted.");
            }

            return delivery;
        }
    }
}
