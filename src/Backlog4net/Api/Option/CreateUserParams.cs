using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class CreateUserParams : PostParams
    {
        public CreateUserParams(string userId, string password, string name, string mailAddress, UserRoleType roleType)
        {
            AddNewParam("userId", userId);
            AddNewParam("password", password);
            AddNewParam("name", name);
            AddNewParam("mailAddress", mailAddress);
            AddNewParam("roleType", roleType.ToString("D"));
        }
    }
}
