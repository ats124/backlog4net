using System;
using System.IO;
namespace Backlog4net.Internal.File
{
    public class IconImpl : Icon
    {
        public IconImpl(string filename, Stream content)
        {
            this.Filename = filename;
            this.Content = content;
        }

        public string Filename { get; private set; }

        public Stream Content { get; private set; }
    }
}
