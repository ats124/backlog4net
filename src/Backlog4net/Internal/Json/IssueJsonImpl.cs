using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json
{
    public class IssueJsonImpl : Issue
    {
        internal class JsonConverter : InterfaceConverter<Issue, IssueJsonImpl> { };

        [JsonProperty]
        public int Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string IssueKey { get; private set; }

        [JsonProperty]
        public long KeyId { get; private set; }

        [JsonIgnore]
        public string KeyIdAsString => KeyId.ToString();

        [JsonProperty]
        public long ProjectId { get; private set; }

        [JsonIgnore]
        public string ProjectIdAsString => ProjectId.ToString();

        [JsonProperty]
        public IssueType IssueType { get; private set; }

        [JsonProperty]
        public string Summary { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty(ItemConverterType = typeof(ResolutionJsonImpl.JsonConverter))]
        public Resolution Resolution { get; private set; }

        [JsonProperty(ItemConverterType = typeof(PriorityJsonImpl.JsonConverter))]
        public Priority Priority { get; private set; }

        [JsonProperty(ItemConverterType = typeof(MilestoneJsonImpl.JsonConverter))]
        [JsonIgnore]
        public IssueStatusType IssueStatusType => (IssueStatusType)Id;


    }
}
