using System;
using System.IO;

namespace Backlog4net.Internal.File
{
    public class AttachmentDataImpl : AttachmentData
    {
        public AttachmentDataImpl(string filename, Stream content)
        {
            this.FileName = filename;
            this.Content = content;
        }

        public string FileName { get; private set; }

        public Stream Content { get; private set; }
    }
}
