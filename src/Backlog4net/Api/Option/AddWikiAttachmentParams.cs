using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddWikiAttachmentParams : PostParams
    {
        private object wikiId;

        public AddWikiAttachmentParams(object wikiId, IList<object> attachmentIds)
        {
            this.wikiId = wikiId;
            AddNewArrayParams("attachmentId[]", attachmentIds);
        }

        public string WikiId => wikiId.ToString();
    }
}
