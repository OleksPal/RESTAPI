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

        private void UpdateItemInTable(string tableName, string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"UPDATE {tableName} " +
                                             $"SET Name = '{name}', Price = {price}" +
                                             $"WHERE Name = '{name}'", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }

        [HttpPut]
        [Route("UpdateItem")]
        public void UpdateItem(string tableName, string name, double price)
        {
            UpdateItemInTable(tableName, name, price);
        }

        private void AddItem(string tableName, string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"INSERT INTO {tableName}(Name, Price)" +
                                             $" VALUES('{name}',{price});", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }

        [HttpPost]
        [Route("SaveNewItem")]
        public void SaveNewItem(string tableName, string name, double price)
        {
            AddItem(tableName, name, price);
        }

        private void DeleteItem(string tableName, string name)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"DELETE FROM {tableName} WHERE" +
                                             $" Name = '{name}'", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public void DeleteItemFromTable(string tableName, string name)
        {
            DeleteItem(tableName, name);
        }
    }
}