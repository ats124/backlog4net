using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public sealed class ChangeLogJsonImpl : ChangeLog
    {
        internal class JsonConverter : InterfaceConverter<ChangeLog, ChangeLogJsonImpl> { }

        [JsonProperty]
        public string Field { get; private set; }

        [JsonProperty]
        public string NewValue { get; private set; }

        [JsonProperty]
        public string OriginalValue { get; private set; }

        [JsonProperty, JsonConverter(typeof(AttachmentInfoJsonImpl.JsonConverter))]
        public AttachmentInfo AttachmentInfo { get; private set; }

        [JsonProperty, JsonConverter(typeof(AttributeInfoJsonImpl.JsonConverter))]
        public AttributeInfo AttributeInfo { get; private set; }

        [JsonProperty, JsonConverter(typeof(NotificationInfoJsonImpl.JsonConverter))]
        public NotificationInfo NotificationInfo { get; private set; }
    }
}
