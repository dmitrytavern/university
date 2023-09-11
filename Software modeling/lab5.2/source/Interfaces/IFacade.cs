using App.Enums;

namespace App.Interfaces
{
    interface IFacade
    {
        void CreateOrder();

        void AddAddress(string country, string city, string address);

        void AddProduct(ProductsEnum product);

        IOrder ComfirmOrder();
    }
}
