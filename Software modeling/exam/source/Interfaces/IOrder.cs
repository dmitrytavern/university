namespace App.Interfaces
{
    interface IOrder
    {
        string Name { get; }

        double Price { get; }

        double DeliveryPrice { get; set; }

        void SetDeliveryPrice(double price);

        double GetTotal();
    }
}
