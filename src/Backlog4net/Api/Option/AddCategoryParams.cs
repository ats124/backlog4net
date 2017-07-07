using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add category API.
    /// </summary>
    public class AddCategoryParams : PostParams
    {
        private object projectIdOrKey;

        /// <param name="projectidOrKey">the project identifier</param>
        /// <param name="name">the category name</param>
        public AddCategoryParams(object projectIdOrKey, string name)
        {
            this.projectIdOrKey = projectIdOrKey;
            AddNewParam("name", name);
        }

        /// <summary>
        /// Returns the project identifier string.
        /// </summary>
        public string ProjectIdOrKeyString => projectIdOrKey.ToString();
    }
}
