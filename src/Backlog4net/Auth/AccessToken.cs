using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Auth
{
    public interface AccessToken
    {
        string Type { get; }
        string Token { get; }
        long Expires { get; }
        string Refresh { get; }
    }
}
