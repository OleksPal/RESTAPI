using System;

namespace WebAPI
{
    internal class ProgramFactory
    {
        public static void RunProgram()
        {
            var exemplarData = new DataFactory();
            var availableStores = exemplarData.GetAvailableStores();
            var wishList = exemplarData.GetWishList();

            var exemplarWife = new WifeFactory();
            var wife = exemplarWife.GetWife(wishList);

            var exemplarHusband = new HusbandFactory();
            var husband = exemplarHusband.GetHusband(wishList);

            Console.WriteLine("Total list:");
            var allItems = husband.GetAllItems(availableStores);
            wife.Print(allItems);

            Console.WriteLine("\nBought:");
            var purchasedItems = husband.WasPurchased(allItems, wishList);
            wife.Print(purchasedItems);

            var totalPrice = husband.GetTotalPrice(purchasedItems);
            wife.Print(totalPrice);
        }
    }
}