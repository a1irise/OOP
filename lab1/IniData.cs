using System.Collections.Generic;
using System;

namespace lab1
{
    public class IniData
    {
        public List<Section> Sections { get; }

        public IniData()
        {
            Sections = new List<Section>();
        }

        public void AddSection(Section section)
        {
            Sections.Add(section);
        }

        public Section FindSection(string name)
        {
            foreach (var section in Sections)
                if (section.Name == name)
                    return section;
            return new Section(name);
        }

        public bool TryGetString(out string result, string entryName, string sectionName = "default")
        {
            result = "";
            foreach (var section in Sections)
                if (section.Name == sectionName.ToLower())
                    foreach (var entry in section.Entries)
                        if (entry.Name == entryName.ToLower())
                        {
                            result = entry.Value;
                            return true;
                        }
            return false;
        }

        public string GetString(string entryName, string sectionName = "default")
        {
            if (!TryGetString(out string result, entryName, sectionName))
                throw new EntryNotFoundException(entryName, sectionName);
            return result;
        }

        public bool TryGetInt(out int result, string entryName, string sectionName = "default")
        {
            if (!TryGetString(out string str, entryName, sectionName))
            {
                result = 0;
                return false;
            }
            if (!double.TryParse(str, out double temp))
            {
                result = -1;
                return false;
            }
            result = Convert.ToInt32(temp);
            return true;
        }

        public int GetInt(string entryName, string sectionName = "default")
        {
            if (!TryGetInt(out int result, entryName, sectionName))
            {
                if (result == 0)
                    throw new EntryNotFoundException(entryName, sectionName);
                if (result == -1)
                    throw new InvalidCastException(entryName, sectionName, "int");
            }
            return result;
        }

        public bool TryGetDouble(out double result, string entryName, string sectionName = "default")
        {
            if (!TryGetString(out string temp, entryName, sectionName))
            {
                result = 0;
                return false;
            }
            if (!double.TryParse(temp, out result))
            {
                result = -1;
                return false;
            }
            return true;
        }

        public double GetDouble(string entryName, string sectionName = "default")
        {
            if (!TryGetDouble(out double result, entryName, sectionName))
            {
                if (result == 0)
                    throw new EntryNotFoundException(entryName, sectionName);
                if (result == -1)
                    throw new InvalidCastException(entryName, sectionName, "double");
            }
            return result;
        }
    }
}