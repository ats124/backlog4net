﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class RadioCustomFieldSetting : CustomFieldSettingJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.Radio;

        [JsonProperty]
        public List<ListItemSetting> Items { get; private set; }

        [JsonProperty]
        public bool IsAllowInput { get; private set; }

        [JsonProperty]
        public bool IsAllowAddItem { get; private set; }
    }
}
