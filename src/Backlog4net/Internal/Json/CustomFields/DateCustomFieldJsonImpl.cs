using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class DateCustomFieldJsonImpl : CustomFieldJsonImpl, DateCustomField
    {
        public override CustomFieldType FieldType => CustomFieldType.Date;

        [JsonProperty]
        public DateTime Value { get; private set; }
    }
}
