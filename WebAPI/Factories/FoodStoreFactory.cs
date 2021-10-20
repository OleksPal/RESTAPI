using System.Collections.Generic;

namespace WebAPI
{
    public class FoodStoreFactory
    {
        public FoodStore GetFoodStore() => new();

        public FoodStore GetFoodStore(List<ShopItem> items) 
            => new(items);
    }
}