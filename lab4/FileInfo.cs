namespace lab4
{
    public class FileInfo
    {
        public string Path { get; }
        public long Size { get; }

        public FileInfo(string path)
        {
            Path = path;
            Size = new System.IO.FileInfo(path).Length;
        }

        public FileInfo(string path, long size)
        {
            Path = path;
            Size = size;
        }
    }
}