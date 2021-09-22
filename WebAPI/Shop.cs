using System;
using System.Collections.Generic;

namespace WebAPI
{
    internal abstract class Shop
    {
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
                if (value.Count <= 0)
                    throw new ArithmeticException("Shop must sell at least something");
                this.items = value;
            }
            get => this.items;
        }
    }

    internal class FoodStore : Shop
    {
        public FoodStore() : base() { }
        public FoodStore(List<ShopItem> items) : base(items) { }
    }

    internal class AppliancesStore : Shop
    {
        public AppliancesStore() : base() { }
        public AppliancesStore(List<ShopItem> items) : base(items) { }
    }
}