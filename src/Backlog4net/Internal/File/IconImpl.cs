﻿using System;
using System.IO;
namespace Backlog4net.Internal.File
{
    public class IconImpl : Icon
    {
        public IconImpl(string filename, Stream content)
        {
            this.FileName = filename;
            this.Content = content;
        }

        public string FileName { get; private set; }

        public Stream Content { get; private set; }
    }
}
