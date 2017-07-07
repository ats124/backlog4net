using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class FileUpdatedActivity : ActivityJsonImpl<FileUpdatedContent>
    {
        public override ActivityType Type => ActivityType.FileUpdated;
    }

    public class FileUpdatedContent : Content
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
