using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateWikiParams : PatchParams
    {
        public UpdateWikiParams(long wikiId)
        {
            this.WikiId = wikiId;
        }

        public long WikiId { get; private set; }

        public string Name { set => AddNewParamValue(value); }

        public string Content { set => AddNewParamValue(value); }

        public bool MailNotify { set => AddNewParamValue(value); }
    }
}
