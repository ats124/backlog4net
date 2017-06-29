using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Backlog4net.Internal.File
{
    public class SharedFileDataImpl : SharedFileData
    {
        public SharedFileDataImpl(string filename, Stream content)
        {
            this.FileName = filename;
            this.Content = content;
        }

        public string FileName { get; private set; }

        public Stream Content { get; private set; }
    }
}
