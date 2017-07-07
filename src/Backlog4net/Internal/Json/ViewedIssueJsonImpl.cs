using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class ViewedIssueJsonImpl : ViewedIssue
    {
        internal class JsonConverter : InterfaceConverter<ViewedIssue, ViewedIssueJsonImpl> { }

        [JsonProperty, JsonConverter(typeof(IssueJsonImpl.JsonConverter))]
        public Issue Issue { get; private set; }

        [JsonProperty]
        public DateTime? Updated { get; private set; }
    }
}
