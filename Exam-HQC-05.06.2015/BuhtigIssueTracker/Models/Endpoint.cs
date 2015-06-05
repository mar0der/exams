namespace BuhtigIssueTracker.Models
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using global::BuhtigIssueTracker.Interfaces;

    #endregion

    public class Endpoint : IEndpoint
    {
        public Endpoint(string endpointString)
        {
            var questionMark = endpointString.IndexOf('?');
            if (questionMark != -1)
            {
                this.ActionName = endpointString.Substring(0, questionMark);
                var pairs =
                    endpointString.Substring(questionMark + 1)
                        .Split('&')
                        .Select(x => x.Split('=').Select(WebUtility.UrlDecode).ToArray());
                var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);

                this.Parameters = parameters;
            }
            else
            {
                this.ActionName = endpointString;
            }
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }
    }
}