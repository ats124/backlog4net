using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.CustomFields
{
    public class TextCustomFieldSettingJsonImpl : CustomFieldSettingJsonImpl, TextCustomFieldSetting
    {
        public override CustomFieldType FieldType => CustomFieldType.Text;
    }
}
