using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.POCO.Files
{
    public partial class FileStateInfo
    {
        public bool IsInitialized { get; set; }
        public string FileName { get; set; }
        public int BufferSize { get; set; }

        public int TotalFileSize { get; set; } = 0;
        public long CurrentFileOffset { get; set; } = 0;

        public string Tag { get; set; }
    }
}
