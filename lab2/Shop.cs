using System;
using System.Collections.Generic;

namespace lab2
{
    class Shop
    {
        public string Id { get; }
        public string Name { get; }
        public string Address { get; }

        public Shop(string name, string address)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Address = address;
        }

        private List<Product> Inventory { get; } = new List<Product>();

        private Product FindProduct(Item item)
        {
            foreach (var product in Inventory)
                if (product.Item == item)
                    return product;
            
            return null;
        }

        public void AddProduct(Item item, int amount, int price)
        {
            var product = FindProduct(item);

            if (product != null)
            {
                product.Amount += amount;
                product.Price = price;
            }
            else
            {
                Inventory.Add(new Product(item, amount, price));
            }
        }

        public int GetItemPrice(Item item)
        {
            var product = FindProduct(item);
            return product == null ? int.MaxValue : product.Price;
        }

        public void GetListOfItemsForTheMoney(int money)
        {
            var items = new List<KeyValuePair<Item, int>>();

            foreach (var product in Inventory)
            {
                int amount = money / product.Price;

                if (amount == 0)
                    continue;

                if (amount > product.Amount)
                    amount = product.Amount;

                items.Add(new KeyValuePair<Item, int>(product.Item, amount));
                money -= amount * product.Price;
            }

            foreach (var item in items)
                Console.WriteLine($"{item.Key.Name} x{item.Value}");
        }

        public int BuyListOfItems(List<KeyValuePair<Item, int>> items, bool reduceAmountInInventory = true)
        {
            int cost = 0;

            foreach (var item in items)
            {
                var product = FindProduct(item.Key);
                
                if (product == null || product.Amount < item.Value)
                    return -1;
                
                cost += item.Value * product.Price;
                
                if (reduceAmountInInventory)
                    product.Amount -= item.Value;
            }

            return cost;
        }
    }
}