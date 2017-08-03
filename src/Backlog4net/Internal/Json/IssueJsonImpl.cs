using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    using Json.CustomFields;

    public class IssueJsonImpl : Issue
    {
        internal class JsonConverter : InterfaceConverter<Issue, IssueJsonImpl> { };

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string IssueKey { get; private set; }

        [JsonProperty]
        public long KeyId { get; private set; }

        [JsonProperty]
        public long ProjectId { get; private set; }

        [JsonProperty, JsonConverter(typeof(IssueTypeJsonImpl.JsonConverter))]
        public IssueType IssueType { get; private set; }

        [JsonProperty]
        public string Summary { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty, JsonConverter(typeof(ResolutionJsonImpl.JsonConverter))]
        public Resolution Resolution { get; private set; }

        [JsonProperty, JsonConverter(typeof(PriorityJsonImpl.JsonConverter))]
        public Priority Priority { get; private set; }

        [JsonProperty, JsonConverter(typeof(StatusJsonImpl.JsonConverter))]
        public Status Status { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User Assignee { get; private set; }

        [JsonProperty(ItemConverterType = typeof(CategoryJsonImpl.JsonConverter))]
        public Category[] Category { get; private set; }

        [JsonProperty(ItemConverterType = typeof(VersionJsonImpl.JsonConverter))]
        public Version[] Versions { get; private set; }

        [JsonProperty(ItemConverterType = typeof(MilestoneJsonImpl.JsonConverter))]
        public Milestone[] Milestone { get; private set; }

        [JsonProperty]
        public DateTime? StartDate { get; private set; }

        [JsonProperty]
        public DateTime? DueDate { get; private set; }

        [JsonProperty]
        public decimal? EstimatedHours { get; private set; }

        [JsonProperty]
        public decimal? ActualHours { get; private set; }

        [JsonProperty]
        public long? ParentIssueId { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User UpdatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Updated { get; private set; }

        [JsonProperty(ItemConverterType = typeof(CustomFieldJsonImpl.JsonConverter))]
        public CustomField[] CustomFields { get; private set; }

        [JsonProperty(ItemConverterType = typeof(AttachmentJsonImpl.JsonConverter))]
        public Attachment[] Attachments { get; private set; }

        [JsonProperty(ItemConverterType = typeof(SharedFileJsonImpl.JsonConverter))]
        public SharedFile[] SharedFiles { get; private set; }

        [JsonProperty(ItemConverterType = typeof(StarJsonImpl.JsonConverter))]
        public Star[] Stars { get; private set; }
    }
}
