using System.Collections.Generic;

namespace WebAPI
{
    public interface IAppliancesStoreRepository
    {
        void AddItem(string name, double price);
        List<ShopItem> GetItems();
        void UpdateItemInTable(string name, double price);
        void DeleteItemFromTable(string name);
    }
}