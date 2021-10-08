using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI
{
    public class FullStoreService : IFullStoreService
    {
        public Task<List<ShopItem>> AllItems
        {
            get 
            {
                IStoreRepository fsr = new FoodStoreRepository();
                IStoreRepository asr = new AppliancesStoreRepository();
                List<ShopItem> items = new();
                items.AddRange(fsr.ItemList);
                items.AddRange(asr.ItemList);
                return Task.FromResult(items);
            } 
        }
    }
}