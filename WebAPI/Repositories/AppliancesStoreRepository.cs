using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebAPI
{
    public class AppliancesStoreRepository : IStoreRepository
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\komp\Documents\GitHub\RESTAPI\WebAPI\Database.mdf;
        Integrated Security=True;MultipleActiveResultSets=true;";

        public List<ShopItem> ItemList
        {
            get
            {
                IGetAppliancesStoreItemList df = new DataFactory();
                return df.AppliancesStoreItemList;
            }
        }

        public async Task AddItem(string name, double price)
        {
            await using (SqlConnection sqlConnection = new(connectionString))
            {
                await sqlConnection.OpenAsync();
                await using (SqlCommand command = new SqlCommand($"INSERT INTO AppliancesStoreItems(Name, Price)" +
                                             $" VALUES('{name}',{price});", sqlConnection)) 
                {
                    SqlDataReader sqlReader = await command.ExecuteReaderAsync();                    
                }                
            }
        }

        public async Task<List<ShopItem>> GetItemsByName(string name)
        {
            List<ShopItem> answer = new();
            await using (SqlConnection sqlConnection = new(connectionString))
            {
                await sqlConnection.OpenAsync();
                await using (SqlCommand command = new SqlCommand($"SELECT * FROM AppliancesStoreItems" +
                                             $" WHERE Name = '{name}'", sqlConnection))
                {
                    await using (SqlDataReader sqlReader = command.ExecuteReader())
                    {
                        if (sqlReader != null)
                        {
                            while (await sqlReader.ReadAsync())
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

        public async Task UpdateItemInTable(string name, double price)
        {
            await using (SqlConnection sqlConnection = new(connectionString))
            {
                await sqlConnection.OpenAsync();
                await using (SqlCommand command = new SqlCommand($"UPDATE AppliancesStoreItems" +
                                             $" SET Name = '{name}'," +
                                             $" Price = {price} " +
                                             $" WHERE Name = '{name}'", sqlConnection))
                {
                    SqlDataReader sqlReader = await command.ExecuteReaderAsync();
                }                    
            }
        }

        public async Task DeleteItemFromTable(string name)
        {
            await using (SqlConnection sqlConnection = new(connectionString))
            {
                await sqlConnection.OpenAsync();
                await using (SqlCommand command = new SqlCommand($"DELETE FROM AppliancesStoreItems WHERE" +
                                             $" Name = '{name}'", sqlConnection)) 
                {
                    SqlDataReader sqlReader = command.ExecuteReader();
                }                
            }
        }
    }
}