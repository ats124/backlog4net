using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateWikiParams : PatchParams
    {
        private object wikiId;

        public UpdateWikiParams(object wikiId)
        {
            this.wikiId = wikiId;
        }

        public string WikiId => wikiId.ToString();

        public string Name { set => AddNewParamValue(value); }

        public string Content { set => AddNewParamValue(value); }

        public bool MailNotify { set => AddNewParamValue(value); }
    }
}
