using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class FileAddedActivityImpl : ActivityJsonImpl<FileAddedContentImpl>, FileAddedActivity
    {
        public override ActivityType Type => ActivityType.FileAdded;

        FileAddedContent FileAddedActivity.Content => this.Content;
    }

    public class FileAddedContentImpl : FileAddedContent
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonIgnore]
        public bool IsImage => Extensions.IsImageName(Name);

        [JsonProperty]
        public string Dir { get; private set; }
        
        [JsonProperty]
        public long Size { get; private set; }
    }
}
