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
        /// <param name="projectidOrKey">the project identifier</param>
        /// <param name="name">the category name</param>
        public AddCategoryParams(IdOrKey projectIdOrKey, string name)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            AddNewParam("name", name);
        }
        public IdOrKey ProjectIdOrKey { get; private set; }
    }
}
