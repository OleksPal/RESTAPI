using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace WebAPI
{
    public class AppliancesStoreRepository : IStoreRepository
    {
        public List<ShopItem> ItemList
        {
            get
            {
                SampleContext context = new();
                List<ShopItem> list = context.ShopItems.Where(item => item.Shop.ShopId == 2).ToList();
                return list;
            }
        }

        public async Task AddItem(string name, double price)
        {
            ShopItemFactory sif = new();
            ShopItem newShopItem = sif.GetShopItem(name, price);

            AppliancesStoreFactory asf = new();
            AppliancesStore appliancesStore = asf.GetAppliancesStore();
            appliancesStore.ShopId = 2;

            newShopItem.Shop = appliancesStore;

            SampleContext context = new();
            context.ShopItems.Add(newShopItem);
            await context.SaveChangesAsync();
        }

        public async Task<ShopItem> GetItemsByName(string name)
        {
            SampleContext context = new();
            return await context.ShopItems.FirstOrDefaultAsync(item => item.Name == name && item.Shop.ShopId == 2);
        }

        public async Task UpdateItemInTable(string name, double price)
        {
            SampleContext context = new();
            var shopItem = context.ShopItems.FirstOrDefaultAsync(item => item.Name == name && item.Shop.ShopId == 2).Result;
            shopItem.Price = price;
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemFromTable(string name)
        {
            SampleContext context = new();
            var shopItem = context.ShopItems.FirstOrDefaultAsync(item => item.Name == name && item.Shop.ShopId == 2).Result;
            context.ShopItems.Remove(shopItem);
            await context.SaveChangesAsync();
        }
    }
}