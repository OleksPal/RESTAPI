using System.Collections.Generic;

namespace WebAPI
{
    public interface IAppliancesStoreService
    {
        void Add(string name, double price);
        List<ShopItem> GetItems(string name);
        List<ShopItem> GetItems();
        void Update(string name, double price);
        void Delete(string name);
    }
}