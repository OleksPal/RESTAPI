using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace WebAPI
{
    public class FoodStoreRepository : IFoodStoreRepository
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\komp\source\repos\WebAPI\WebAPI\Database.mdf;
        Integrated Security=True";

        public void AddItem(string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"INSERT INTO FoodStoreItems(Name, Price)" +
                                             $" VALUES('{name}',{price});", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }

        public List<ShopItem> GetItems(string name)
        {
            List<ShopItem> allItems = GetItems();
            List<ShopItem> answer = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                foreach (var item in allItems)
                {
                    if (name == item.Name)
                        answer.Add(item);
                }
            }
            return answer;
        }

        public List<ShopItem> GetItems()
        {
            List<ShopItem> allItems = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                var command = new SqlCommand("SELECT * FROM FoodStoreItems", sqlConnection);
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
                    allItems.Add(new ShopItem(sqlReader.GetString("Name"),
                        (double)sqlReader.GetDecimal("Price")));
                }
            }
            return allItems;
        }

        public void UpdateItemInTable(string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"INSERT INTO FoodStoreItems(Name, Price)" +
                                             $" VALUES('{name}',{price});", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }

        public void DeleteItemFromTable(string name)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"DELETE FROM FoodStoreItems WHERE" +
                                             $" Name = '{name}'", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }
    }
}