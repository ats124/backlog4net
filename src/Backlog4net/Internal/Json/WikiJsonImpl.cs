using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
	public sealed class WikiJsonImpl : Wiki
	{
		internal class JsonConverter : InterfaceConverter<Wiki, WikiJsonImpl> { }

		[JsonProperty]
		public long Id { get; private set; }

        [JsonIgnore]
		public string IdAsString => Id.ToString();

		[JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Content { get; private set; }

        [JsonProperty(ItemConverterType = typeof(WikiTagJsonImpl.JsonConverter))]
        public WikiTag[] Tags { get; private set; }

        [JsonProperty(ItemConverterType = typeof(AttachmentJsonImpl.JsonConverter))]
        public Attachment[] Attachments { get; private set; }

        [JsonProperty(ItemConverterType = typeof(SharedFileJsonImpl.JsonConverter))]
        public SharedFile[] SharedFiles { get; private set; }

        [JsonProperty(ItemConverterType = typeof(StarJsonImpl.JsonConverter))]
        public Star[] Stars { get; private set; }

        [JsonProperty]
        public long ProjectId { get; private set; }

        [JsonIgnore]
        public string ProjectIdAsString => ProjectId.ToString();

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime Created { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User UpdatedUser { get; private set; }

        [JsonProperty]
        public DateTime Updated { get; private set; }
	}
}