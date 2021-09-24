using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;   

namespace WebAPI
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllItemsInFoodStore")]
        public List<ShopItem> GetAllItemsInFoodStore()
        {
            FoodStoreService fss = new();
            return fss.GetItems();
        }

        [HttpGet]
        [Route("GetAllItemsInAppliancesStore")]
        public List<ShopItem> GetAllItemsInAppliancesStore()
        {
            AppliancesStoreService appSS = new();
            return appSS.GetItems();
        }

        [HttpGet]
        [Route("GetAllItemsInAllShops")]
        public List<ShopItem> GetAllItemsInAllShops()
        {
            FullStoreService fullSS = new FullStoreService();
            return fullSS.GetAll();
        }

        [HttpGet]
        [Route("GetItemsFromFoodStore")]
        public List<ShopItem> GetItemsFromFoodStore(string name)
        {
            FoodStoreService fss = new FoodStoreService();
            return fss.GetItems(name);
        }

        [HttpGet]
        [Route("GetItemFromAppliancesStore")]
        public List<ShopItem> GetItemFromAppliancesStore(string name)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            return appSS.GetItems(name);
        }

        [HttpPut]
        [Route("UpdateItemInFoodStore")]
        public void UpdateItemInFoodStore(string name, double price)
        {
            FoodStoreService fss = new FoodStoreService();
            fss.Update(name, price);
        }

        [HttpPut]
        [Route("UpdateItemInAppliancesStore")]
        public void UpdateItemInAppliancesStore(string name, double price)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            appSS.Update(name, price);
        }

        [HttpPost]
        [Route("SaveNewItemInFoodStore")]
        public void SaveNewItemInFoodStore(string name, double price)
        {
            FoodStoreService fss = new FoodStoreService();
            fss.Add(name, price);
        }

        [HttpPost]
        [Route("SaveNewItemInAppliancesStore")]
        public void SaveNewItemInAppliancesStore(string name, double price)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            appSS.Add(name, price);
        }

        [HttpDelete]
        [Route("DeleteItemFromFoodStore")]
        public void DeleteItemFromFoodStore(string name)
        {
            FoodStoreService fss = new FoodStoreService();
            fss.Delete(name);
        }

        [HttpDelete]
        [Route("DeleteItemFromAppliancesStore")]
        public void DeleteItemFromAppliancesStore(string name)
        {
            AppliancesStoreService appSS = new AppliancesStoreService();
            appSS.Delete(name);
        }
    }
}