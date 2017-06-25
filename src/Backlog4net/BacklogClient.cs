using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Auth;

    public interface BacklogClient : UserMethods
    {
        void SetOAuthSupport(OAuthSupport oAuthSupport);
    }
}
