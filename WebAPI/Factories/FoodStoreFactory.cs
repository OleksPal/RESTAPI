using System.Collections.Generic;

namespace WebAPI
{
    internal class FoodStoreFactory
    {
        public FoodStore GetFoodStore() => new();

        public FoodStore GetFoodStore(List<ShopItem> items) 
            => new(items);
    }
}