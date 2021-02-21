using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.CleanupAlgorithms
{
    public class AmountSizeCleanupAlgorithm : CleanupAlgorithm
    {
        public int MaxAmount { get; set; }
        public long MaxSize { get; set; }

        public AmountSizeCleanupAlgorithm(int maxAmount, long maxSize)
        {
            MaxAmount = maxAmount;
            MaxSize = maxSize;
        }

        public override void Cleanup(List<RestorePoint> restorePoints)
        {
            long size = 0;
            foreach (var restorePoint in restorePoints)
                size += restorePoint.Size;

            while (restorePoints.Count > MaxAmount || size > MaxSize)
            {
                if (!CanClean(restorePoints))
                    throw new UnableToClearRestorePointsException();

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