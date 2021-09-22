using System.Collections.Generic;

namespace WebAPI
{
    public class FoodStoreService : IFoodStoreService
    {
        FoodStoreRepository fsr = new();

        public void Add(string name, double price)
        {            
            fsr.AddItem(name, price);
        }

        public void Delete(string name)
        {
            fsr.DeleteItemFromTable(name);
        }

        public List<ShopItem> GetItems(string name)
        {
            return fsr.GetItems(name);
        }

        public List<ShopItem> GetItems()
        {
            return fsr.GetItems();
        }

        public void Update(string name, double price)
        {
            fsr.UpdateItemInTable(name, price);
        }
    }
}