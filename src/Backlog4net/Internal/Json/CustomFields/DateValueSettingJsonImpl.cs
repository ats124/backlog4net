using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class DateValueSettingJsonImpl : DateValueSetting
    {
        internal class JsonConverter : InterfaceConverter<DateValueSetting, DateValueSettingJsonImpl> { }

        [JsonProperty("id")]
        public DateCustomFieldInitialValueType ValueType { get; private set; }

        [JsonProperty]
        public DateTime? Date { get; private set; }

        [JsonProperty]
        public int? Shift { get; private set; }
    }
}
