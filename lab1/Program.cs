using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ini = new IniParser();
            var data = ini.Parse(Console.ReadLine());
            data.TryGetString(out string s, "LegacyValue", "Common");
            data.TryGetInt(out int i, "LegacyValue", "Common");
            data.TryGetDouble(out double d, "LegacyValue", "Common");
        }
    }
}