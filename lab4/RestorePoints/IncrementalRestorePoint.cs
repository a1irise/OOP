using System.Collections.Generic;

namespace lab4.RestorePoints
{
    public class IncrementalRestorePoint : RestorePoint
    {
        public IncrementalRestorePoint(List<FileInfo> files)
            : base(files) { }
    }
}