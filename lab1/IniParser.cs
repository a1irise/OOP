using System;
using System.Collections.Generic;
using System.IO;

namespace lab1
{
    public class IniParser
    {
        public IniData Parse(string file)
        {
            if (!File.Exists(file))
                throw new Exception($"{file} does not exist.");
            if (file.Substring(file.Length - 4) != ".ini")
                throw new Exception($"{file.Substring(file.Length - 4)} is not a supported file extension.");
            
            var data = new IniData();

            try
            {
                data = GetData(file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }

        private IniData GetData(string file)
        {
            var data = new IniData();

            var lines = FormatFile(file);
            var currentSection = new Section("default");

            for (int i = 0; i < lines.Count; i++)
            {
                string currentLine = lines[i];

                if (currentLine[0] == '[' && currentLine[currentLine.Length - 1] == ']')
                {
                    data.AddSection(currentSection);
                    string name = currentLine.Remove(currentLine.Length - 1).Remove(0, 1).ToLower();
                    currentSection = data.FindSection(name);
                }
                else currentSection.AddEntry(currentLine);
            }
            data.AddSection(currentSection);

            return data;
        }

        private List<string> FormatFile(string file)
        {
            var lines = new List<string>(File.ReadAllLines(file));

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Replace(" ", "").Replace(".", ",");
                if (lines[i].IndexOf(';') != -1)
                    lines[i] = lines[i].Remove(lines[i].IndexOf(';'));
                if (lines[i] == string.Empty)
                    lines[i] = "delete marker";
            }
            lines.RemoveAll(IsMarked);

            return lines;
        }

        private bool IsMarked(string str)
        {
            return str == "delete marker";
        }
    }
}