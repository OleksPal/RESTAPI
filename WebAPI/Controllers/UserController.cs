using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllItemsInFoodStore")]
        public async Task<List<ShopItem>> GetAllItemsInFoodStore()
        {
            IStoreService fss = new FoodStoreService();
            return await fss.GetItems();
        }

        [HttpGet]
        [Route("GetAllItemsInAppliancesStore")]
        public async Task<List<ShopItem>> GetAllItemsInAppliancesStore()
        {
            IStoreService appSS = new AppliancesStoreService();
            return await appSS.GetItems();
        }

        [HttpGet]
        [Route("GetAllItemsInAllShops")]
        public async Task<List<ShopItem>> GetAllItemsInAllShops()
        {
            IFullStoreService fullSS = new FullStoreService();
            return await fullSS.AllItems;
        }

        [HttpGet]
        [Route("GetItemsFromFoodStore")]
        public async Task<ShopItem> GetItemsFromFoodStore(string name)
        {
            IStoreService fss = new FoodStoreService();
            return await fss.GetItems(name);
        }

        [HttpGet]
        [Route("GetItemsFromAppliancesStore")]
        public async Task<ShopItem> GetItemsFromAppliancesStore(string name)
        {
            IStoreService appSS = new AppliancesStoreService();
            return await appSS.GetItems(name);
        }

        [HttpPut]
        [Route("UpdateItemInFoodStore")]
        public async Task UpdateItemInFoodStore(string name, double price)
        {
            IStoreService fss = new FoodStoreService();
            await fss.Update(name, price);
        }

        [HttpPut]
        [Route("UpdateItemInAppliancesStore")]
        public async Task UpdateItemInAppliancesStore(string name, double price)
        {
            IStoreService appSS = new AppliancesStoreService();
            await appSS.Update(name, price);
        }

        [HttpPost]
        [Route("SaveNewItemInFoodStore")]
        public async Task SaveNewItemInFoodStore(string name, double price)
        {
            IStoreService fss = new FoodStoreService();
            await fss.Add(name, price);
        }

        [HttpPost]
        [Route("SaveNewItemInAppliancesStore")]
        public async Task SaveNewItemInAppliancesStore(string name, double price)
        {
            IStoreService appSS = new AppliancesStoreService();
            await appSS.Add(name, price);
        }

        [HttpDelete]
        [Route("DeleteItemFromFoodStore")]
        public async Task DeleteItemFromFoodStore(string name)
        {
            IStoreService fss = new FoodStoreService();
            await fss.Delete(name);
        }

        [HttpDelete]
        [Route("DeleteItemFromAppliancesStore")]
        public async Task DeleteItemFromAppliancesStore(string name)
        {
            IStoreService appSS = new AppliancesStoreService();
            await appSS.Delete(name);
        }
    }
}