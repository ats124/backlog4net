using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    public enum UserRoleType
    {
        Admin = 1,
        User = 2,
        Reporter = 3,
        Viewer = 4,
        GuestReporter = 5,
        GuestViewer = 6,
    }

    /// <summary>
    /// Backlog user data.
    /// </summary>
    public sealed class User
    {
        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

        [JsonProperty]
        public string Name { get; private set; }

        private static readonly string[] imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        public bool IsImage
        {
            get
            {
                var lowerCase = Name.ToLowerInvariant();
                return imageExtensions.Any(x => lowerCase.EndsWith(x));
            }
        }

        [JsonProperty]
        public UserRoleType RoleType { get; private set; }

        [JsonProperty]
        public string Lang { get; private set; }

        [JsonProperty]
        public string MailAddress { get; private set; }

        [JsonProperty]
        public string UserId { get; private set; }
    }
}
