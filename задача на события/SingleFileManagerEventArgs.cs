using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventTask
{
    internal class SingleFileManagerEventArgs: EventArgs
    {
        public string Message { get; set; }
        public string FileName { get; set; }
        public string AppendData { get; set; }
    }
}
