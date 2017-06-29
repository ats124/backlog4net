using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class ViewedWikiJsonImpl : ViewedWiki
    {
        internal class JsonConverter : InterfaceConverter<ViewedWiki, ViewedWikiJsonImpl> { }

        [JsonProperty, JsonConverter(typeof(WikiJsonImpl.JsonConverter))]
        public Wiki Page { get; private set; }
    
        [JsonProperty]
        public DateTime Updated { get; private set; }
    }
}
