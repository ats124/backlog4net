using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateCategoryParams : PatchParams
    {
        private object projectIdOrKey;
        private object categoryId;

        public UpdateCategoryParams(object projectIdOrKey, object categoryId, string name)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.categoryId = categoryId;
            AddNewParam("name", name);
        }

        public string ProjectIdOrKeyString => projectIdOrKey.ToString();

        public string CategoryId => categoryId.ToString();
    }
}
