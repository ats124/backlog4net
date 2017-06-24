using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Auth
{
    using Backlog4net.Auth;

    public class AccessTokenJsonImpl : AccessToken
    {
        [JsonProperty("token_type")]
        public string Type { get; private set; }

        [JsonProperty("token_type")]
        public string Token { get; private set; }

        [JsonProperty("expires_in")]
        public long Expires { get; private set; }

        [JsonProperty("refresh_token")]
        public string Refresh { get; private set; }
    }
}
