﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Conf
{
    using Auth;

    public abstract class BacklogConfigure
    {
        public const int DEFAULT_TIMUEOUT = 100000;

        public AccessToken AccessToken { get; set; }
        public string ApiKey { get; set; }
        public int Timeout { get; set; } = DEFAULT_TIMUEOUT;
        public abstract string OAuthAuthorizationUrl { get; }
        public abstract string OAuthAccessTokenUrl { get; }
        public abstract string RestBaseUrl { get; }
        public abstract string WebAppBaseUrl { get; }
    }
}
