using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class PullRequestJsonImpl : PullRequest
    {
        internal class JsonConverter : InterfaceConverter<PullRequest, PullRequestJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonIgnore]
        public string IdAsString => Id.ToString();

        [JsonProperty]
        public long ProjectId { get; private set; }

        [JsonIgnore]
        public string ProjectIdAsString => ProjectId.ToString();

        [JsonProperty]
        public long RepositoryId { get; private set; }

        [JsonIgnore]
        public string RepositoryIdAsString => RepositoryId.ToString();

        [JsonProperty]
        public long Number { get; private set; }
        
        [JsonProperty]
        public string Summary { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public string Base { get; private set; }

        [JsonProperty]
        public string Branch { get; private set; }

        [JsonProperty, JsonConverter(typeof(PullRequestStatusJsonImpl.JsonConverter))]
        public PullRequestStatus Status { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User Assignee { get; private set; }

        [JsonProperty, JsonConverter(typeof(IssueJsonImpl.JsonConverter))]
        public Issue Issue { get; private set; }

        [JsonProperty]
        public string MergeCommit { get; private set; }

        [JsonProperty]
        public string BaseCommit { get; private set; }

        [JsonProperty]
        public string BranchCommit { get; private set; }

        [JsonProperty]
        public string CloseAt { get; private set; }

        [JsonProperty]
        public string MergeAt { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime Created { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User UpdatedUser { get; private set; }

        [JsonProperty]
        public DateTime Updated { get; private set; }

        [JsonProperty(ItemConverterType = typeof(AttachmentJsonImpl.JsonConverter))]
        public Attachment[] Attachments { get; private set; }

        [JsonProperty(ItemConverterType = typeof(StarJsonImpl.JsonConverter))]
        public Star[] Stars { get; private set; }

    }
}
