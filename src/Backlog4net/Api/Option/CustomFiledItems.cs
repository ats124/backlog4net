using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CustomFiledItems
    {
        private object customFieldId;

        public CustomFiledItems(object customFieldId, IList<object> customFieldItemIds)
        {
            this.customFieldId = customFieldId;
            this.CustomFieldItemIds = new List<string>(customFieldItemIds.Select(x => x.ToString()));
        }

        public string CustomFieldId => customFieldId.ToString();

        public List<string> CustomFieldItemIds { get; private set; }
    }

}
