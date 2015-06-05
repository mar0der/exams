namespace BuhtigIssueTracker.Core
{
    #region

    using System;
    using System.Collections.Generic;

    using global::BuhtigIssueTracker.Enumerations;
    using global::BuhtigIssueTracker.Interfaces;
    using global::BuhtigIssueTracker.Utils;

    #endregion

    public class Dispatcher
    {
        public Dispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public Dispatcher()
            : this(new IssueTracker())
        {
        }

        private IIssueTracker Tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.ProcessRegisterUserCommand(endpoint.Parameters);
                case "LoginUser":
                    return this.ProcessLoginUserCommand(endpoint.Parameters);
                case "LogoutUser":
                    return this.ProcessLogoutUserCommand();
                case "CreateIssue":
                    return this.ProcessCreateIssueCommand(endpoint.Parameters);
                case "RemoveIssue":
                    return this.ProcessRemoveIssueCommand(endpoint.Parameters);
                case "AddComment":
                    return this.ProcessAddCommentCommand(endpoint.Parameters);
                case "MyIssues":
                    return this.ProcessMyIssuesCommand();
                case "MyComments":
                    return this.ProcessMyCommentsCommand();
                case "Search":
                    return this.ProcessSearchCommand(endpoint.Parameters);
                default:
                    return string.Format(Messages.IvalidActionWithName, endpoint.ActionName);
            }
        }

        private string ProcessRegisterUserCommand(IDictionary<string, string> parameters)
        {
            var output = this.Tracker.RegisterUser(
                parameters["username"], 
                parameters["password"], 
                parameters["confirmPassword"]);
            return output;
        }

        private string ProcessLoginUserCommand(IDictionary<string, string> parameters)
        {
            var output = this.Tracker.LoginUser(parameters["username"], parameters["password"]);
            return output;
        }

        private string ProcessLogoutUserCommand()
        {
            var output = this.Tracker.LogoutUser();
            return output;
        }

        private string ProcessCreateIssueCommand(IDictionary<string, string> parameters)
        {
            var issuePriority = (IssuePriority)Enum.Parse(typeof(IssuePriority), parameters["priority"], true);
            var tags = parameters["tags"].Split('|');
            var output = this.Tracker.CreateIssue(parameters["title"], parameters["description"], issuePriority, tags);
            return output;
        }

        private string ProcessAddCommentCommand(IDictionary<string, string> parameters)
        {
            var issueId = int.Parse(parameters["id"]);
            var output = this.Tracker.AddComment(issueId, parameters["text"]);
            return output;
        }

        private string ProcessRemoveIssueCommand(IDictionary<string, string> parameters)
        {
            var issueId = int.Parse(parameters["id"]);
            var output = this.Tracker.RemoveIssue(issueId);
            return output;
        }

        private string ProcessMyIssuesCommand()
        {
            var output = this.Tracker.GetMyIssues();
            return output;
        }

        private string ProcessMyCommentsCommand()
        {
            var output = this.Tracker.GetMyComments();
            return output;
        }

        private string ProcessSearchCommand(IDictionary<string, string> parameters)
        {
            var tags = parameters["tags"].Split('|');
            var output = this.Tracker.SearchForIssues(tags);
            return output;
        }
    }
}