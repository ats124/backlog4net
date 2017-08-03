using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class AddWikiAttachmentParams : PostParams
    {
        public AddWikiAttachmentParams(long wikiId, IList<long> attachmentIds)
        {
            this.WikiId = wikiId;
            AddNewArrayParams("attachmentId[]", attachmentIds);
        }

        public long WikiId { get; private set; }
    }
}
