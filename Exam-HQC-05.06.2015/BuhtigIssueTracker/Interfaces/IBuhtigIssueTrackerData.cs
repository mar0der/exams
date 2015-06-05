namespace BuhtigIssueTracker.Interfaces
{
    #region

    using System.Collections.Generic;

    using global::BuhtigIssueTracker.Models;

    using Wintellect.PowerCollections;

    #endregion

    public interface IBuhtigIssueTrackerData
    {
        User CurrentLoggedUser { get; set; }

        IDictionary<string, User> AllUsers { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUsername { get; }

        MultiDictionary<string, Issue> TagsIssues { get; }

        MultiDictionary<User, Comment> UsersComments { get; }

        int AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}