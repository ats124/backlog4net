using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog changeLog data.
    /// </summary>
    public sealed class ChangeLog
    {
        [JsonProperty]
        public long Field { get; private set; }

        [JsonProperty]
        public string NewValue { get; private set; }

        [JsonProperty]
        public string OriginalValue { get; private set; }

        [JsonProperty]
        public AttachmentInfo AttachmentInfo { get; private set; }

        [JsonProperty]
        public AttributeInfo AttributeInfo { get; private set; }

        [JsonProperty]
        public NotificationInfo NotificationInfo { get; private set; }
    }
}
