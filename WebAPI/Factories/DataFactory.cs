using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebAPI
{
    internal class DataFactory : IGetFoodStoreItemList, IGetAppliancesStoreItemList
    {
        private List<ShopItem> foodStoreItemList;
        private List<ShopItem> appliancesStoreItemList;

        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\komp\Documents\GitHub\RESTAPI\WebAPI\Database.mdf;
        Integrated Security=True;MultipleActiveResultSets=true;";

        public List<ShopItem> FoodStoreItemList 
        {
            get 
            {
                GetStoreItemList("FoodStoreItems");
                return foodStoreItemList;
            }
        }

        public List<ShopItem> AppliancesStoreItemList
        {
            get
            {
                GetStoreItemList("AppliancesStoreItems");
                return appliancesStoreItemList;
            }
        }

        public void GetStoreItemList(string tableName)
        {
            List<ShopItem> itemList = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                // Do work here; connection closed on following line.
                using (SqlCommand command = new SqlCommand("SELECT * FROM " + tableName,
                    sqlConnection)) 
                {
                    using (SqlDataReader sqlReader = command.ExecuteReader()) 
                    {
                        while (sqlReader.Read())
                        {
                            itemList.Add(new ShopItem(sqlReader.GetString("Name"),
                                (double)sqlReader.GetDecimal("Price")));
                        }
                        if (tableName == "FoodStoreItems")
                            foodStoreItemList = itemList;
                        if (tableName == "AppliancesStoreItems")
                            appliancesStoreItemList = itemList;
                    }
                }                
            }
        }

        public List<Shop> GetAvailableStores()
        {
            var exemplarFoodFactory = new FoodStoreFactory();
            var exemplarAppliancesFactory = new AppliancesStoreFactory();
            GetStoreItemList("FoodStoreItems");
            GetStoreItemList("AppliancesStoreItems");
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
