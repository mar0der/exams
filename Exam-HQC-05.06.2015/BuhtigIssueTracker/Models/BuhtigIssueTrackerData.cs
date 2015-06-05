namespace BuhtigIssueTracker.Models
{
    #region

    #region

    using System.Collections.Generic;

    using global::BuhtigIssueTracker.Interfaces;

    using Wintellect.PowerCollections;

    #endregion

    #endregion

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public BuhtigIssueTrackerData()
        {
            this.NextIssueId = 1;
            this.AllUsers = new Dictionary<string, User>();
            this.Issues = new MultiDictionary<Issue, string>(true);
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.TagsIssues = new MultiDictionary<string, Issue>(true);
            this.UsersComments = new MultiDictionary<User, Comment>(true);
        }

        public int NextIssueId { get; set; }

        public MultiDictionary<Issue, string> Issues { get; set; }

        public User CurrentLoggedUser { get; set; }

        public IDictionary<string, User> AllUsers { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUsername { get; set; }

        public MultiDictionary<string, Issue> TagsIssues { get; set; }

        public MultiDictionary<User, Comment> UsersComments { get; set; }

        User IBuhtigIssueTrackerData.CurrentLoggedUser
        {
            get
            {
                return this.CurrentLoggedUser;
            }

            set
            {
                this.CurrentLoggedUser = value;
            }
        }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.NextIssueId;
            this.IssuesById.Add(issue.Id, issue);
            this.NextIssueId++;
            this.IssuesByUsername[this.CurrentLoggedUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.TagsIssues[tag].Add(issue);
            }

            return issue.Id;
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssuesByUsername[this.CurrentLoggedUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.TagsIssues[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
        }
    }
}