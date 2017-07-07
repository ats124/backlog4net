using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class FileDeletedActivity : ActivityJsonImpl<FileDeletedContent>
    {
        public override ActivityType Type => ActivityType.FileDeleted;
    }

    public class FileDeletedContent : Content
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
