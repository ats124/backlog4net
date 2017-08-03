using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class AttachmentJsonImpl : Attachment
    {
        internal class JsonConverter : InterfaceConverter<Attachment, AttachmentJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonIgnore]
        public bool IsImage => Extensions.IsImageName(Name);

        [JsonProperty]
        public long Size { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }
    }
}
