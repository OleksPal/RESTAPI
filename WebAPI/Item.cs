using System;

namespace WebAPI
{
    public abstract class Item 
    {
        public string name;         
               
        public string Name
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Item name can’t be empty");
                this.name = value;
            }
            get => this.name;
        }

        protected Item(string name) 
        { 
            this.name = name;
        }

        protected Item() { } 
    }

    public class ShopItem : Item
    {
        public double price;

        public ShopItem(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public ShopItem() : base() { }

        public double Price
        {
            set
            {
                if (value <= 0)
                    throw new ArithmeticException("Price can’t be negative or zero");
                this.price = value;
            }
            get => this.price;
        }
    }

    public class WishItem : Item {
        public WishItem() : base() { }
        public WishItem(string name) : base(name) { }
    }
}