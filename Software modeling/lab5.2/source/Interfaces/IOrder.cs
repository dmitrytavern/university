namespace App.Interfaces
{
    interface IOrder
    {
        public void AddProduct(IProduct product);

        public void SetDelivery(IDelivery _delivery);

        public decimal GetTotal();

        public IDelivery GetDelivery();
    }
}
