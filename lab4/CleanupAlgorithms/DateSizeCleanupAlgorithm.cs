using System;
using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.CleanupAlgorithms
{
    public class DateSizeCleanupAlgorithm : CleanupAlgorithm
    {
        public DateTime MaxDate { get; set; }
        public double MaxSize { get; set; }

        public DateSizeCleanupAlgorithm(DateTime maxDate, double maxSize)
        {
            MaxDate = maxDate;
            MaxSize = maxSize;
        }

        public override void Cleanup(List<RestorePoint> restorePoints)
        {
            long size = 0;
            foreach (var restorePoint in restorePoints)
                size += restorePoint.Size;

            while (restorePoints[0].CreationTime < MaxDate || size > MaxSize)
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