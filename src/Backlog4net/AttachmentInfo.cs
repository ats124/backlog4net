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
    public sealed class AttachmentInfo
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

        public override bool Equals(object obj) => 
            obj is AttachmentInfo info && (this.Id, this.Name).Equals((info.Id, info.Name));

        public override int GetHashCode() => (this.Id, this.Name).GetHashCode();

    }
}
