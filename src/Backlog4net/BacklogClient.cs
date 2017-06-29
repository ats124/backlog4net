using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    using Api;
    using Auth;

    public interface BacklogClient : 
        GitMethods, GroupMethods, ImportMethods, IssueMethods, NotificationMethods,
        PriorityMethods, ProjectMethods, PullRequestMethods, ResolutionMethods, SpaceMethods,
        StarMethods, StatusMethods, UserMethods, WatchingMethods, WebhookMethods, WikiMethods
    {
        void SetOAuthSupport(OAuthSupport oAuthSupport);
    }
}
