using System.Collections.Generic;

namespace lab2
{
    public class Utility
    {
        private List<Shop> _shops = new List<Shop>();

        public Shop CreateShop(string name, string address)
        {
            var shop = new Shop(name, address);
            _shops.Add(shop);
            return shop;
        }

        public Shop FindCheapest(Item item)
        {
            Shop res = null;
            var minPrice = int.MaxValue;

            foreach (var shop in _shops)
            {
                if (shop.GetItemPrice(item) >= minPrice)
                    continue;
                
                minPrice = shop.GetItemPrice(item);
                res = shop;
            }
            
            return minPrice == int.MaxValue ? null : res;
        }
        
        public Shop FindCheapest(List<KeyValuePair<Item, int>> items)
        {
            Shop res = null;
            var minPrice = int.MaxValue;

            foreach (var shop in _shops)
            {
                if (shop.BuyListOfItems(items, false) >= minPrice || shop.BuyListOfItems(items, false) == -1)
                    continue;
                
                minPrice = shop.BuyListOfItems(items, false);
                res = shop;
            }

            return minPrice == int.MaxValue ? null : res;
        }
    }
}