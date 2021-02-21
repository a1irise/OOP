using System.Collections.Generic;

namespace lab4.RestorePoints
{
    public class FullRestorePoint : RestorePoint
    {
        public FullRestorePoint(List<FileInfo> files)
            : base(files)
        { }
    }
}