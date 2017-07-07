using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog user data.
    /// </summary>
    public interface User
    {
        long Id { get; }

        string IdAsString { get; }

        string Name { get; }

        bool IsImage { get; }

        UserRoleType RoleType { get; }

        string Lang { get; }

        string MailAddress { get; }

        string UserId { get; }
    }

    public enum UserRoleType
    {
        Admin = 1,
        User = 2,
        Reporter = 3,
        Viewer = 4,
        GuestReporter = 5,
        GuestViewer = 6,
    }
}
