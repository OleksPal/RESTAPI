using System.Collections.Generic;

namespace WebAPI
{
    public class AppliancesStoreService : IAppliancesStoreService
    {
        AppliancesStoreRepository asr = new();

        public void Add(string name, double price)
        {            
            asr.AddItem(name, price);
        }

        public void Delete(string name)
        {
            asr.DeleteItemFromTable(name);
        }

        public List<ShopItem> GetItems(string name)
        {
            return asr.GetItems(name);
        }

        public List<ShopItem> GetItems()
        {
            return asr.GetItems();
        }

        public void Update(string name, double price)
        {
            asr.UpdateItemInTable(name, price);
        }
    }
}