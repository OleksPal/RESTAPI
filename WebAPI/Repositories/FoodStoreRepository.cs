using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI
{
    public class FoodStoreRepository : IFoodStoreRepository
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\komp\source\repos\WebAPI\WebAPI\Database.mdf;
        Integrated Security=True;MultipleActiveResultSets=true;";
        SqlDataReader sqlReader = null;

        public void AddItem(string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"INSERT INTO FoodStoreItems(Name, Price)" +
                                             $" VALUES('{name}',{price});", sqlConnection);

                sqlReader = command.ExecuteReader();
            }
        }

        public List<ShopItem> GetItems(string name)
        {
            List<ShopItem> answer = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM FoodStoreItems" +
                                             $" WHERE Name = '{name}'", sqlConnection))
                {
                    using (SqlDataReader sqlReader = command.ExecuteReader())
                    {
                        if (sqlReader != null)
                        {
                            while (sqlReader.Read())
                            {
                                answer.Add(new ShopItem(sqlReader.GetString("Name"),
                                    (double)sqlReader.GetDecimal("Price")));
                            }
                        }
                    } // reader closed and disposed up here
                }
            }
            return answer;
        }

        public List<ShopItem> GetItems()
        {
            DataFactory df = new();
            return df.GetStoreItemList("FoodStoreItems");
        }

        public void UpdateItemInTable(string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"UPDATE FoodStoreItems" +
                                             $" SET Name = '{name}'," +
                                             $" Price = {price} " +
                                             $" WHERE Name = '{name}'", sqlConnection);

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

                
                sqlReader = command.ExecuteReader();
            }
        }
    }
}