using System;

namespace lab1
{
    public class UnsupportedFileExtensionException : Exception
    {
        public UnsupportedFileExtensionException()
            : base($"Unsupported file extension.")
        { }
    }

    public class InvalidEntryFormatException : Exception
    {
        public InvalidEntryFormatException(string str)
            : base($"{str} is an invalid entry.")
        { }
    }

    public class EntryNotFoundException : Exception
    {
        public EntryNotFoundException(string entry, string section)
            : base($"Unable to find {entry} in {section}.")
        { }
    }

    public class InvalidCastException : Exception
    {
        public InvalidCastException(string entry, string section, string type)
            : base($"Unable to convert value of {entry} in {section} to {type}.")
        { }
    }
}