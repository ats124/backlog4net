using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// The error message class for Backlog exception.
    /// </summary>
    public class BacklogApiErrorMessage
    {
        [JsonProperty]
        public string Message { get; private set; }
        [JsonProperty]
        public int Code { get; private set; }
        [JsonProperty]
        public string ErrorInfo { get; private set; }
        [JsonProperty]
        public string MoreInfo { get; private set; }
    }
}
