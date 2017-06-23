using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Backlog attachment file.
    /// </summary>
    public sealed class Attachment
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
        public long Size { get; private set; }

        [JsonProperty]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime Created { get; private set; }
    }
}
