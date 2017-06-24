using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net
{
    /// <summary>
    /// Exception thrown when a api response contains error.
    /// </summary>
    public class BacklogApiException : BacklogException
    {
        public BacklogApiException() { }
        public BacklogApiException(string message) : base(message)
        {
            Decode(message);
        }
        public BacklogApiException(string message, Exception inner, int statusCode) : base(message, inner)
        {
            Decode(message);
            this.StatusCode = statusCode;
        }

        public BacklogApiErrorType? ErrorType { get; private set; }

        public BacklogApiError BacklogApiError { get; private set; }

        public int StatusCode { get; private set; }

        public override string Message
        {
            get
            {
                var strBuilder = new StringBuilder(base.Message);
                if (StatusCode > 0)
                {
                    strBuilder.AppendLine().AppendFormat("status code - {0]", StatusCode);
                }
                if (BacklogApiError != null)
                {
                    foreach (var errorMessage in BacklogApiError.Errors)
                    {
                        strBuilder
                            .AppendLine()
                            .Append("message - ").Append(errorMessage.Message).AppendLine()
                            .Append("code - ").Append(errorMessage.Code).AppendLine();
                        if (!string.IsNullOrEmpty(errorMessage.ErrorInfo))
                            strBuilder.Append("errorInfo - ").Append(errorMessage.ErrorInfo).AppendLine();
                        if (!string.IsNullOrEmpty(errorMessage.MoreInfo))
                            strBuilder.Append("moreInfo - ").Append(errorMessage.MoreInfo).AppendLine();
                    }
                }
                return strBuilder.ToString();
            }
        }

        protected void Decode(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.StartsWith("{"))
                this.BacklogApiError = JsonConvert.DeserializeObject<BacklogApiError>(str);
        }
    }
}
