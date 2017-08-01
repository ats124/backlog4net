using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add issue type API.
    /// </summary>
    public class AddIssueTypeParams : PostParams
    {
        public AddIssueTypeParams(IdOrKey projectIdOrKey, string name, string color)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            AddNewParam("color", color);
            AddNewParam("name", name);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }
    }
}
