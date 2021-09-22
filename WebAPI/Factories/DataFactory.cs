using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI
{
    internal class DataFactory
    {
        public List<ShopItem> foodStoreItemList = new();
        public List<ShopItem> appliancesStoreItemList = new();

        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
            C:\Users\komp\source\repos\ProblemShopping1\ProblemShopping1\Database.mdf;Integrated Security=True";

        public void GetStoreItemList(string tableName, List<ShopItem> list)
        {
            using (SqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();
                // Do work here; connection closed on following line.
                var command = new SqlCommand("SELECT * FROM " + tableName, sqlConnection);

                SqlDataReader sqlReader = null;

                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    list.Add(new ShopItem(sqlReader.GetString("Name"),
                        (double)sqlReader.GetDecimal("Price")));
                }
            }
        }

        public List<Shop> GetAvailableStores()
        {
            var exemplarFoodFactory = new FoodStoreFactory();
            var exemplarAppliancesFactory = new AppliancesStoreFactory();
            GetStoreItemList("FoodStoreItems", foodStoreItemList);
            GetStoreItemList("AppliancesStoreItems", appliancesStoreItemList);
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
