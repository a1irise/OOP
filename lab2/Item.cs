using System;

namespace lab2
{
    public class Item
    {
        public string Id { get; }
        public string Name { get; }

        public Item(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}