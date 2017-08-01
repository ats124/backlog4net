using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class UpdateCategoryParams : PatchParams
    {
        public UpdateCategoryParams(IdOrKey projectIdOrKey, long categoryId, string name)
        {
            this.ProjectIdOrKey = projectIdOrKey;
            this.CategoryId = categoryId;
            AddNewParam("name", name);
        }

        public IdOrKey ProjectIdOrKey { get; private set; }

        public long CategoryId { get; private set; }
    }
}
