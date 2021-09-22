using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI
{
    internal abstract class Human
    {
        protected List<WishItem> wishList;

        protected Human(List<WishItem> list)
        {
            this.wishList = list;
        }

        protected Human() { }

        public List<WishItem> WishList
        {
            set
            {
                if (value.Count <= 0)
                    throw new ArithmeticException("Wish list can’t be empty");
                wishList = value;
            }
            get => this.wishList;
        }
    }

    internal interface IWife 
    {
        void Print(List<ShopItem> itemList);
    }

    internal class Wife : Human, IWife 
    {
        public Wife() : base() { }
        public Wife(List<WishItem> list) : base(list) { }

        public void Print(List<ShopItem> itemList)
        {
            foreach (var item in itemList)
            {
                Console.WriteLine($"{item.Name} - {item.Price}");
            }
        }

        public void Print(double price)
        {
            Console.WriteLine($"Total price = {price}");
        }
    }

    internal interface IHusband 
    {
        List<ShopItem> WasPurchased(List<ShopItem> allItems, List<WishItem> wishList);
        List<ShopItem> GetAllItems(List<Shop> availableShops);
        double GetTotalPrice(List<ShopItem> wasPurchased);
    }

    internal class Husband : Human, IHusband 
    {
        public Husband() : base() { }
        public Husband(List<WishItem> list) : base(list) { } 

        public List<ShopItem> WasPurchased(List<ShopItem> allItems, List<WishItem> wishList)
        {
            List<ShopItem> purchasedList = new();
            foreach (var wishItem in wishList)
            {
                if(wishItem == null) continue;
                foreach (var shopItem in allItems)
                {
                    if (shopItem.Name == wishItem.Name)
                        purchasedList.Add(shopItem);
                }
            }
            return purchasedList;
        }

        public List<ShopItem> GetAllItems(List<Shop> availableShops)
        {
            List<ShopItem> resultList = new();
            foreach (var shop in availableShops)
            {
                if (shop.items == null) continue;
                resultList.AddRange(from item in shop.Items select item);
            }
            return resultList;
        }

        public double GetTotalPrice(List<ShopItem> wasPurchased)
        {
            var total = wasPurchased.Sum(item => item.Price);
            return total;
        }
    }
}