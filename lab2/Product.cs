namespace lab2
{
    public class Product
    {
        public Item Item { get; }
        public int Amount { get; set; }
        public int Price { get; set; }

        public Product(Item item, int amount, int price)
        {
            Item = item;
            Amount = amount;
            Price = price;
        }
    }
}