using System.Collections.Generic;
using System.IO;

namespace lab1
{
    public class IniParser
    {
        public IniData Parse(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException(file);
            if (file.Substring(file.Length - 4) != ".ini")
                throw new UnsupportedFileExtensionException();

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
            lines.RemoveAll(s => s == "delete marker");

            return lines;
        }
    }
}