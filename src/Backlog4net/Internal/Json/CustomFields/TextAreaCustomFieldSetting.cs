using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class TextAreaCustomFieldSetting : CustomFieldSettingJsonImpl
    {
        public override CustomFieldType FieldType => CustomFieldType.TextArea;
    }
}
