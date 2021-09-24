using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI
{
    public class AppliancesStoreRepository : IAppliancesStoreRepository
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\komp\source\repos\WebAPI\WebAPI\Database.mdf;
        Integrated Security=True;MultipleActiveResultSets=true;";

        public void AddItem(string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"INSERT INTO AppliancesStoreItems(Name, Price)" +
                                             $" VALUES('{name}',{price});", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }

        public List<ShopItem> GetItems(string name)
        {
            List<ShopItem> answer = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM AppliancesStoreItems" +
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
            return df.GetStoreItemList("AppliancesStoreItems");
        }

        public void UpdateItemInTable(string name, double price)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"UPDATE AppliancesStoreItems" +
                                             $" SET Name = '{name}'," +
                                             $" Price = {price} " +
                                             $" WHERE Name = '{name}'", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }

        public void DeleteItemFromTable(string name)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"DELETE FROM AppliancesStoreItems WHERE" +
                                             $" Name = '{name}'", sqlConnection);

                SqlDataReader sqlReader = null;
                sqlReader = command.ExecuteReader();
            }
        }
    }
}