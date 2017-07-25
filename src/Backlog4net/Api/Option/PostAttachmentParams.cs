using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class PostAttachmentParams : List<KeyValuePair<string, object>>, AttachmentData
    {
        public PostAttachmentParams(string fileName, Stream content)
        {
            this.FileName = fileName;
            this.Content = content;
            this.Add(new KeyValuePair<string, object>("file", this));
        }

        public string FileName  { get; private set; }

        public Stream Content { get; private set; }

        public void Dispose()
        {
            if (Content != null) Content.Dispose();
        }
    }
}
