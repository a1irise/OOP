namespace lab1
{
    public class Entry
    {
        public string Name { get; }
        public string Value { get; }

        public Entry(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}