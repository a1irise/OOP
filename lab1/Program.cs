using System;
namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ini = new IniParser();
            var data = ini.Parse("L:\\test.ini");
            
        }
    }
}