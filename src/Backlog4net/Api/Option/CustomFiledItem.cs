using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CustomFiledItem
    {
        private object customFieldId;
        private object customFieldItemId;

        public CustomFiledItem(object customFieldId, object customFieldItemId)
        {
            this.customFieldId = customFieldId;
            this.customFieldItemId = customFieldItemId;
        }

        public string CustomFieldId => customFieldId.ToString();

        public string CustomFieldItemId => customFieldItemId == null ? "" : customFieldItemId.ToString();
    }
}
