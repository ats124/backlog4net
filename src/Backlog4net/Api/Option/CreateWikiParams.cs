using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CreateWikiParams : PostParams
    {
        public CreateWikiParams(object projectId, string name, string content)
        {
            AddNewParam("projectId", projectId);
            AddNewParam("name", name);
            AddNewParam("content", content);
        }

        public bool MailNotify { set => AddNewParamValue(value); }
    }
}
