using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    /// <summary>
    /// Parameters for add custom field API.
    /// </summary>
    public abstract class AddCustomFieldParams : PostParams
    {
        private object projectIdOrKey;

        public AddCustomFieldParams(object projectIdOrKey, CustomFieldType fieldType, string name)
        {
            this.projectIdOrKey = projectIdOrKey;
            AddNewParam("typeId", fieldType.ToString("D"));
            AddNewParam("name", name);
        }

        /// <summary>
        /// Returns the project identifier string.
        /// </summary>
        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public IList<long> ApplicableIssueTypes { set => AddNewArrayParamValues(value); }

        public string Description { set => AddNewParamValue(value); }

        public bool Required { set => AddNewParamValue(value); }
    }
}
