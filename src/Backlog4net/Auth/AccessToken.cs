using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Auth
{
    public class AccessToken
    {
        public string Type { get; private set; }
        public string Token { get; private set; }
        public long Expires { get; private set; }
        public string Refresh { get; private set; }

        public AccessToken(string token, long expires, string refresh)
        {
            this.Token = token;
            this.Expires = expires;
            this.Refresh = refresh;
        }
    }
}
