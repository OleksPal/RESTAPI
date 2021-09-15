using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;   
using System;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\komp\source\repos\WebAPI\WebAPI\Database.mdf;
        Integrated Security=True";

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

        private List<ShopItem> GetItemList(string tableName)
        {
            List<ShopItem> list = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand("SELECT * FROM " + tableName, sqlConnection);

                SqlDataReader sqlReader = null;

                try
                {
                    sqlReader = command.ExecuteReader();
                }
                catch (Exception e)
                {
                    return null;
                }

                while (sqlReader.Read())
                {
                    list.Add(new ShopItem(sqlReader.GetString("Name"),
                        (double)sqlReader.GetDecimal("Price")));
                }
            }
            return list;
        }

        private List<ShopItem> GetAllItems()
        {
            List<ShopItem> allItems = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                List<string> tablesList = GetTables(connectionString);

                foreach (var tableName in tablesList)
                {
                    List<ShopItem> itemsInShop = GetAllItemsInStore(
                        tableName.Substring(0, tableName.Length - 5));
                    foreach (var item in itemsInShop)
                    {
                        allItems.Add(item);
                    }
                }
            }
            return allItems;
        }

        private List<string> GetTables(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }

        [HttpGet]
        [Route("GetAllItemsInStore")]
        public List<ShopItem> GetAllItemsInStore(string storeName)
        {
            string tableName = storeName + "Items";
            return GetItemList(tableName);
        }

        [HttpGet]
        [Route("GetAllItemsInAllShops")]
        public List<ShopItem> GetAllItemsInAllShops()
        {
            return GetAllItems();
        }

        [HttpGet]
        [Route("GetItemOnName")]
        public ShopItem GetItemOnName(string name)
        {
            List<ShopItem> allItems = GetAllItems();
            foreach (var item in allItems)
            {
                if (name == item.Name)
                    return item;
            }
            return new ShopItem();
        }

        [HttpGet]
        [Route("GetItemPrice")]
        public double GetItemPrice(string name)
        {
            List<ShopItem> allItems = GetAllItems();
            foreach (var item in allItems)
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