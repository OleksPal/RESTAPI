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
            FoodStoreService fss = new();
            return await fss.GetItems();
        }

        [HttpGet]
        [Route("GetAllItemsInAppliancesStore")]
        public async Task<List<ShopItem>> GetAllItemsInAppliancesStore()
        {
            AppliancesStoreService appSS = new();
            return await appSS.GetItems();
        }

        [HttpGet]
        [Route("GetAllItemsInAllShops")]
        public async Task<List<ShopItem>> GetAllItemsInAllShops()
        {
            FullStoreService fullSS = new FullStoreService();
            return await fullSS.GetAll();
        }

        [HttpGet]
        [Route("GetItemsFromFoodStore")]
        public async Task<List<ShopItem>> GetItemsFromFoodStore(string name)
        {
            FoodStoreService fss = new FoodStoreService();
            return await fss.GetItems(name);
        }

        [HttpGet]
        [Route("GetItemsFromAppliancesStore")]
        public async Task<List<ShopItem>> GetItemsFromAppliancesStore(string name)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            return await appSS.GetItems(name);
        }

        [HttpPut]
        [Route("UpdateItemInFoodStore")]
        public async Task UpdateItemInFoodStore(string name, double price)
        {
            FoodStoreService fss = new FoodStoreService();
            await fss.Update(name, price);
        }

        [HttpPut]
        [Route("UpdateItemInAppliancesStore")]
        public async Task UpdateItemInAppliancesStore(string name, double price)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            await appSS.Update(name, price);
        }

        [HttpPost]
        [Route("SaveNewItemInFoodStore")]
        public async Task SaveNewItemInFoodStore(string name, double price)
        {
            FoodStoreService fss = new FoodStoreService();
            await fss.Add(name, price);
        }

        [HttpPost]
        [Route("SaveNewItemInAppliancesStore")]
        public async Task SaveNewItemInAppliancesStore(string name, double price)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            await appSS.Add(name, price);
        }

        [HttpDelete]
        [Route("DeleteItemFromFoodStore")]
        public async Task DeleteItemFromFoodStore(string name)
        {
            FoodStoreService fss = new FoodStoreService();
            await fss.Delete(name);
        }

        [HttpDelete]
        [Route("DeleteItemFromAppliancesStore")]
        public async Task DeleteItemFromAppliancesStore(string name)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            await appSS.Delete(name);
        }
    }
}