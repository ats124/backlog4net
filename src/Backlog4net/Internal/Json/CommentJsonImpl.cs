using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class CommentJsonImpl : Comment
    {
        internal class JsonConverter : InterfaceConverter<Comment, CommentJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Content { get; private set; }
    }
}
