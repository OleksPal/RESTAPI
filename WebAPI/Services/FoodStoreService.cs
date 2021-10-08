using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public class FoodStoreService : IStoreService
    {
        IStoreRepository fsr = new FoodStoreRepository();

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
            return await fsr.GetItemsByName(name);
        }

        public async Task<List<ShopItem>> GetItems()
        {
            return await Task.FromResult(fsr.ItemList);
        }

        public async Task Update(string name, double price)
        {
            await fsr.UpdateItemInTable(name, price);
        }
    }
}