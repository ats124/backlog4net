using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class DateCustomFieldSettingJsonImpl : CustomFieldSettingJsonImpl, DateCustomFieldSetting
    {
        public override CustomFieldType FieldType => CustomFieldType.Date;

        [JsonProperty]
        public DateTime? Min { get; private set; }

        [JsonProperty]
        public DateTime? Max { get; private set; }

        [JsonProperty(ItemConverterType = typeof(DateValueSettingJsonImpl.JsonConverter))]
        public DateValueSetting InitialDate { get; private set; }
    }
}
