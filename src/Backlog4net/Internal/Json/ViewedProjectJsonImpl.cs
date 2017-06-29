using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class ViewedProjectJsonImpl : ViewedProject
    {
        internal class JsonConverter : InterfaceConverter<ViewedProject, ViewedProjectJsonImpl> { }

        [JsonProperty, JsonConverter(typeof(ProjectJsonImpl.JsonConverter))]
        public Project Project { get; private set; }
    
        [JsonProperty]
        public DateTime Updated { get; private set; }
    }
}
