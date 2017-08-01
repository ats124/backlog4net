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
        protected AddCustomFieldParams(IdOrKey projectIdOrKey, CustomFieldType fieldType, string name)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            AddNewParam("typeId", fieldType.ToString("D"));
            AddNewParam("name", name);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public IList<long> ApplicableIssueTypes { set => AddNewArrayParamValues(value); }

        public string Description { set => AddNewParamValue(value); }

        public bool Required { set => AddNewParamValue(value); }
    }
}
