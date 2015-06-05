namespace BuhtigIssueTracker.Core
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::BuhtigIssueTracker.Enumerations;
    using global::BuhtigIssueTracker.Interfaces;
    using global::BuhtigIssueTracker.Models;
    using global::BuhtigIssueTracker.Utils;

    #endregion

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        public BuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentLoggedUser != null)
            {
                return Messages.ThereIsLoggedUser;
            }

            if (password != confirmPassword)
            {
                return Messages.PasswordsNotMatch;
            }

            if (this.Data.AllUsers.ContainsKey(username))
            {
                return string.Format(Messages.UserAlreadyExists, username);
            }

            var user = new User(username, password);
            this.Data.AllUsers.Add(username, user);
            return string.Format(Messages.UserRegisteredSuccessfully, username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Data.CurrentLoggedUser != null)
            {
                return Messages.ThereIsLoggedUser;
            }

            if (!this.Data.AllUsers.ContainsKey(username))
            {
                return string.Format(Messages.UserDoesNotExists, username);
            }

            var user = this.Data.AllUsers[username];
            if (user.PasswordHash != PasswordHasher.HashPassword(password))
            {
                return string.Format(Messages.PasswordIsInvalidForUser, username);
            }

            this.Data.CurrentLoggedUser = user;

            return string.Format(Messages.UserLoggedSuccessfully, username);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return Messages.NoLoggedUser;
            }

            var username = this.Data.CurrentLoggedUser.Username;
            this.Data.CurrentLoggedUser = null;
            return string.Format(Messages.UserLoggedOutSuccessfully, username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return Messages.NoLoggedUser;
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            var newIssueId = this.Data.AddIssue(issue);
            return string.Format(Messages.IssueCreatedSuccessfully, newIssueId);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return Messages.NoLoggedUser;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Messages.NoIssueWithId, issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            if (!this.Data.IssuesByUsername[this.Data.CurrentLoggedUser.Username].Contains(issue))
            {
                return string.Format(
                    Messages.IssueDoesNotBelongToUserWithId, 
                    issueId, 
                    this.Data.CurrentLoggedUser.Username);
            }

            this.Data.RemoveIssue(issue);
            return string.Format(Messages.IssueWithIdRemoved, issueId);
        }

        public string AddComment(int issueId, string commentText)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return Messages.NoLoggedUser;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Messages.NoIssueWithId, issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            var comment = new Comment(this.Data.CurrentLoggedUser, commentText);
            issue.AddComment(comment);
            this.Data.UsersComments[this.Data.CurrentLoggedUser].Add(comment);
            return string.Format(Messages.CommentAddedToIssue, issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return Messages.NoLoggedUser;
            }

            var myIssues = this.Data.IssuesByUsername[this.Data.CurrentLoggedUser.Username];
            if (!myIssues.Any())
            {
                return Messages.NoIssues;
            }

            var output = string.Join(
                Environment.NewLine, 
                myIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
            return output;
        }

        public string GetMyComments()
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return Messages.NoLoggedUser;
            }

            var comments = this.Data.UsersComments[this.Data.CurrentLoggedUser].Select(x => x.ToString()).ToArray();

            if (comments.Length == 0)
            {
                return Messages.NoComment;
            }

            return string.Join(Environment.NewLine, comments);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length == 0)
            {
                return Messages.NoTagsProvided;
            }

            var issuesFound = new List<Issue>();
            foreach (var tag in tags)
            {
                issuesFound.AddRange(this.Data.TagsIssues[tag]);
            }

            if (!issuesFound.Any())
            {
                return Messages.NoIssuesMatchingTheTags;
            }

            var distinctIssues = issuesFound.Distinct();

            return string.Join(
                Environment.NewLine, 
                distinctIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
    }
}