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
        private object projectIdOrKey;

        public AddIssueTypeParams(object projectIdOrKey, string name, string color)
        {
            this.projectIdOrKey = projectIdOrKey;
            AddNewParam("color", color);
            AddNewParam("name", name);
        }

        /// <summary>
        /// Returns the project identifier string.
        /// </summary>
        public string ProjectIdOrKeyString => projectIdOrKey.ToString();
    }
}
