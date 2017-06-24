using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// The error class for Backlog exception.
    /// Contains the error massages.
    /// </summary>
    public class BacklogApiError
    {
        [JsonProperty]
        public BacklogApiErrorMessage[] Errors { get; private set; }

        internal static BacklogApiError Decode(string str) => 
            !string.IsNullOrEmpty(str) && str.StartsWith("{")
                ? JsonConvert.DeserializeObject<BacklogApiError>(str)
                : null;
    }
}