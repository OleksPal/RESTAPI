using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace WebAPI
{
    public class FoodStoreRepository : IStoreRepository
    {
        public List<ShopItem> ItemList 
        {
            get
            {
                SampleContext context = new();
                List<ShopItem> list = context.ShopItems.Where(item => item.Shop.ShopId == 1).ToList();
                return list;
            }
        }

        public async Task AddItem(string name, double price)
        {
            ShopItemFactory sif = new();
            ShopItem newShopItem = sif.GetShopItem(name, price);

            FoodStoreFactory fsf = new();
            FoodStore foodStore = fsf.GetFoodStore();
            foodStore.ShopId = 1;

            newShopItem.Shop = foodStore;

            SampleContext context = new();
            context.ShopItems.Add(newShopItem);
            await context.SaveChangesAsync();
        }

        public Task<ShopItem> GetItemsByName(string name)
        {
            SampleContext context = new();
            return context.ShopItems.FirstOrDefaultAsync(item => item.Name == name && item.Shop.ShopId == 1);
        }

        public async Task UpdateItemInTable(string name, double price)
        {
            SampleContext context = new();
            ShopItem shopItem = context.ShopItems.FirstOrDefaultAsync(item => item.Name == name && item.Shop.ShopId == 1).Result;
            shopItem.Price = price;
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemFromTable(string name)
        {
            SampleContext context = new();
            var shopItem = context.ShopItems.FirstOrDefaultAsync(item => item.Name == name && item.Shop.ShopId == 1).Result;
            context.ShopItems.Remove(shopItem);
            await context.SaveChangesAsync();
        }
    }
}