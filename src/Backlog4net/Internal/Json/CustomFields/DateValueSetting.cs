using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class DateValueSetting
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public DateTime Date { get; private set; }

        [JsonProperty]
        public int Shift { get; private set; }
    }
}
