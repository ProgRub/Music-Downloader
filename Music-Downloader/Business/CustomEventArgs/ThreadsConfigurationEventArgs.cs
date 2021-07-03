using System;
using System.Collections.Generic;

namespace Business.CustomEventArgs
{
    public class ThreadsConfigurationEventArgs:EventArgs
    {
        public int NumberOfThreads { get; set; }
        public IEnumerable<int> NumberOfFilesPerThread { get; set; }
    }
}