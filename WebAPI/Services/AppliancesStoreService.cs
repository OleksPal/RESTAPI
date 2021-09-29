using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public class AppliancesStoreService : IAppliancesStoreService
    {
        AppliancesStoreRepository asr = new();

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
            return await asr.GetItems(name);
        }

        public async Task<List<ShopItem>> GetItems()
        {
            return await asr.GetItems();
        }

        public async Task Update(string name, double price)
        {
            await asr.UpdateItemInTable(name, price);
        }
    }
}