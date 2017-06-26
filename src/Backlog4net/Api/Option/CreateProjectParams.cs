using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CreateProjectParams : PostParams
    {
        public CreateProjectParams(string name, string projectKey, bool chartEnabled, bool subtaskingEnabled, TextFormattingRule textFormattingRule)
        {
            AddNewParam("name", name);
            AddNewParam("key", projectKey);
            AddNewParam("chartEnabled", chartEnabled);
            AddNewParam("subtaskingEnabled", subtaskingEnabled);
            AddNewParam("textFormattingRule", textFormattingRule);
        }
    }
}
