using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class NumericCustomField : CustomFieldJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.Numeric;

        [JsonProperty]
        public decimal Value { get; private set; }
    }
}
