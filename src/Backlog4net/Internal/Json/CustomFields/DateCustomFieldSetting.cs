using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class DateCustomFieldSetting : CustomFieldSettingJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.Date;

        [JsonProperty]
        public DateTime Min { get; private set; }

        [JsonProperty]
        public DateTime Max { get; private set; }

        [JsonProperty]
        public DateValueSetting InitialDate { get; private set; }
    }

    public enum DateCustomFieldInitialValueType
    {
        Today = 1,
        TodayPlusShiftDays = 2,
        FixedDate = 3,
    }
}
