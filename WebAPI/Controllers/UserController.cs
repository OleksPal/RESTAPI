using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;   

namespace WebAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Our fictitious database 
        public List<ShopItem> Items = new()
        {
            new ShopItem("Sharp", 70),
            new ShopItem("Apple", 300),
            new ShopItem("Bread", 110),
            new ShopItem("Sausage", 80),
            new ShopItem("Butter", 70),
            new ShopItem("Milk", 300),
            new ShopItem("Potato", 40)
        };

        [HttpGet]
        [Route("GetAllItems")]
        public List<ShopItem> GetAllItems()
        {
            // Return all Items
            return Items;
        }

        [HttpGet]
        [Route("GetItemOnName")]
        public ShopItem GetItemOnName(string name) 
        {
            // Return a specific item
            foreach (var item in Items)
            {
                if (name == item.Name)
                    return item;
            }
            return new ShopItem();
        }

        [HttpGet]
        [Route("GetPrice")]
        public double GetPrice(string name)
        {
            // Return a specific user
            foreach (var item in Items)
            {
                if (name == item.Name)
                    return item.Price;
            }
            return 0;
        }

        [HttpPut]
        [Route("UpdateItem")]
        public List<ShopItem> UpdateItem(string name, double price)
        {
            ShopItem putItem = new();
            foreach (var item in Items)
            {
                if (name == item.Name)
                    putItem = item;
            }
            Items.Remove(putItem);
            Items.Add(new ShopItem(name, price));
            return Items;
        }

        [HttpPost]
        [Route("SaveNewItem")]
        public List<ShopItem> SaveNewItem(string name, double price)
        {
            Items.Add(new ShopItem(name, price));
            return Items;
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public List<ShopItem> DeleteItem(string name)
        {
            ShopItem deleteItem = new();
            foreach (var item in Items)
            {
                if (name == item.Name)
                    deleteItem = item;
            }
            Items.Remove(deleteItem);
            return Items;
        }
    }
}