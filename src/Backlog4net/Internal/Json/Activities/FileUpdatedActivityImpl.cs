using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class FileUpdatedActivityImpl : ActivityJsonImpl<FileUpdatedContentImpl>, FileUpdatedActivity
    {
        public override ActivityType Type => ActivityType.FileUpdated;

        FileUpdatedContent FileUpdatedActivity.Content => this.Content;
    }

    public class FileUpdatedContentImpl : FileUpdatedContent
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Dir { get; private set; }
        
        [JsonProperty]
        public long Size { get; private set; }
    }
}
