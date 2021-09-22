using System.Collections.Generic;

namespace WebAPI
{
    public class FullStoreService : IFullStoreService
    {
        FoodStoreRepository fsr = new();
        AppliancesStoreRepository asr = new();

        public List<ShopItem> GetAll()
        {
            List<ShopItem> answer = new();
            answer.AddRange(asr.GetItems());
            answer.AddRange(fsr.GetItems());
            return answer;
        }
    }
}