using System;

namespace Business.CustomEventArgs
{
    public class FileMovedArgs : EventArgs
    {
        public string Filename { get; set; }
        public FileMovedCondition Condition { get; set; }
    }

    public enum FileMovedCondition
    {
        NoProblem,
        ReplacedSingle,
        AlreadyExists,
        HadToBeRenamed
    }
}