using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.CleanupAlgorithms
{
    public class SizeCleanupAlgorithm : CleanupAlgorithm
    {
        public long MaxSize { get; set; }

        public SizeCleanupAlgorithm(long maxSize)
        {
            MaxSize = maxSize;
        }

        public override void Cleanup(List<RestorePoint> restorePoints)
        {
            long size = 0;
            foreach (var restorePoint in restorePoints)
                size += restorePoint.Size;
            
            while (size > MaxSize)
            {
                size -= restorePoints[0].Size;
                restorePoints.RemoveAt(0);

                while (restorePoints[0].GetType() != typeof(FullRestorePoint))
                {
                    size -= restorePoints[0].Size;
                    restorePoints.RemoveAt(0);
                }
            }
        }
    }
}