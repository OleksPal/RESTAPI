using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public class AppliancesStoreService : IStoreService
    {
        IStoreRepository asr = new AppliancesStoreRepository();

        public async Task Add(string name, double price)
        {
            await asr.AddItem(name, price);
        }

        public async Task Delete(string name)
        {
            await asr.DeleteItemFromTable(name);
        }

        public async Task<List<ShopItem>> GetItems(string name)
        {
            return await asr.GetItemsByName(name);
        }

        public async Task<List<ShopItem>> GetItems()
        {
            return await Task.FromResult(asr.ItemList);
        }

        public async Task Update(string name, double price)
        {
            await asr.UpdateItemInTable(name, price);
        }
    }
}