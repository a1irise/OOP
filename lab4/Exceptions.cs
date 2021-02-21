using System;

namespace lab4
{
    public class NoNewEditsException : Exception
    {
        public NoNewEditsException()
            : base($"Unable to create incremental restore point, no new changes.")
        { }
    }
    
    public class UnableToClearRestorePointsException : Exception
    {
        public UnableToClearRestorePointsException()
            : base($"Unable to clear restore points, consider add a full restore point before trying again.")
        { }
    }
}