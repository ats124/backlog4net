using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class NumericCustomFieldSettingJsonImpl : CustomFieldSettingJsonImpl, NumericCustomFieldSetting
    {
        public override CustomFieldType FieldType => CustomFieldType.Numeric;

        [JsonProperty]
        public decimal? Min { get; private set; }

        [JsonProperty]
        public decimal? Max { get; private set; }

        [JsonProperty]
        public decimal? InitialValue { get; private set; }

        [JsonProperty]
        public string Unit { get; private set; }
    }
}
