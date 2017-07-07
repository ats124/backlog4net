using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class AttachmentInfoJsonImpl : AttachmentInfo
    {
        internal class JsonConverter : InterfaceConverter<AttachmentInfo, AttachmentInfoJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }
        
        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        private static readonly string[] imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        [JsonIgnore]
        public bool IsImage => Extensions.IsImageName(Name);
    }
}
