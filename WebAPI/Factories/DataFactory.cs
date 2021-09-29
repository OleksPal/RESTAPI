using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebAPI
{
    internal class DataFactory
    {
        public List<ShopItem> foodStoreItemList = new();
        public List<ShopItem> appliancesStoreItemList = new();

        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\Home\Documents\GitHub\RESTAPI\WebAPI\Database.mdf;
        Integrated Security=True;MultipleActiveResultSets=true;";

        public async Task<List<ShopItem>> GetStoreItemList(string tableName)
        {
            List<ShopItem> list = new();
            await using (SqlConnection sqlConnection = new(connectionString))
            {
                await sqlConnection.OpenAsync();
                // Do work here; connection closed on following line.
                await using (SqlCommand command = new SqlCommand("SELECT * FROM " + tableName,
                    sqlConnection)) 
                {
                    await using (SqlDataReader sqlReader = command.ExecuteReader()) 
                    {
                        while (await sqlReader.ReadAsync())
                        {
                            list.Add(new ShopItem(sqlReader.GetString("Name"),
                                (double)sqlReader.GetDecimal("Price")));
                        }
                    }
                }                
            }
            return list;
        }

        public async Task<List<Shop>> GetAvailableStores()
        {
            var exemplarFoodFactory = new FoodStoreFactory();
            var exemplarAppliancesFactory = new AppliancesStoreFactory();
            List<ShopItem> foodStoreItemList = await GetStoreItemList("FoodStoreItems");
            List<ShopItem> appliancesStoreItemList = await GetStoreItemList("AppliancesStoreItems");
            return new List<Shop>
            {
                exemplarFoodFactory.GetFoodStore(foodStoreItemList),
                exemplarAppliancesFactory.GetAppliancesStore(appliancesStoreItemList)
            };
        }

        public List<WishItem> GetWishList()
        {
            var exemplarWishItem = new WishItemFactory();
            return new List<WishItem>
            {
                exemplarWishItem.GetWishItem("Sony"),
                exemplarWishItem.GetWishItem("Bread"),
                exemplarWishItem.GetWishItem("Lenovo"),
                exemplarWishItem.GetWishItem("Onion")
            };
        }
    }
}
