using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public class FoodStoreService : IFoodStoreService
    {
        FoodStoreRepository fsr = new();

        public async Task Add(string name, double price)
        {            
            await fsr.AddItem(name, price);
        }

        public async Task Delete(string name)
        {
            await fsr.DeleteItemFromTable(name);
        }

        public async Task<List<ShopItem>> GetItems(string name)
        {
            return await fsr.GetItems(name);
        }

        public async Task<List<ShopItem>> GetItems()
        {
            return await fsr.GetItems();
        }

        public async Task Update(string name, double price)
        {
            await fsr.UpdateItemInTable(name, price);
        }
    }
}