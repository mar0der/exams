namespace BuhtigIssueTracker.Interfaces
{
    #region

    using System.Collections.Generic;

    #endregion

    public interface IEndpoint
    {
        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}