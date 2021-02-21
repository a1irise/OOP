using System.Collections.Generic;

namespace lab1
{
    public class Section
    {
        public string Name { get; }
        public List<Entry> Entries { get; }

        public Section(string name)
        {
            Name = name;
            Entries = new List<Entry>();
        }

        public void AddEntry(string str)
        {
            if (str.IndexOf('=') == -1 || str.Remove(str.IndexOf('=')) == "" || str.Substring(str.IndexOf('=') + 1) == "")
                throw new InvalidEntryFormatException(str);
            string name = str.Remove(str.IndexOf('=')).ToLower();
            string value = str.Substring(str.IndexOf('=') + 1).ToLower();

            foreach (var entry in Entries)
            {
                if (entry.Name == name)
                    Entries.Remove(entry);
                break;
            }

            Entries.Add(new Entry(name, value));
        }
    }
}