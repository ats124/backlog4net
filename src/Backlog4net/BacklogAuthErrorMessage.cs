using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// The error message class for Backlog auth exception.
    /// </summary>
    public class BacklogAuthErrorMessage
    {
        [JsonProperty]
        public string Error { get; private set; }
        [JsonProperty("error_description")]
        public string Description { get; private set; }

        internal static BacklogAuthErrorMessage Decode(string str) =>
            !string.IsNullOrEmpty(str) && str.StartsWith("{")
                ? JsonConvert.DeserializeObject<BacklogAuthErrorMessage>(str)
                : null;
    }
}
