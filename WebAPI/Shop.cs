using System;
using System.Collections.Generic;

namespace WebAPI
{
    public abstract class Shop
    {
        public int ShopId { get; set; }
        public List<ShopItem> items;

        protected Shop(List<ShopItem> items)
        {
            this.items = items;
        }

        protected Shop() { }

        public List<ShopItem> Items
        {
            set
            {
                if (value == null)
                    throw new ArgumentNullException($"List can’t be null");
                this.items = value;
            }
            get => this.items;
        }
    }

    public class FoodStore : Shop
    {
        public FoodStore() : base() { }
        public FoodStore(List<ShopItem> items) : base(items) { }
    }

    public class AppliancesStore : Shop
    {
        public AppliancesStore() : base() { }
        public AppliancesStore(List<ShopItem> items) : base(items) { }
    }
}