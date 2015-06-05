namespace BuhtigIssueTracker.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using global::BuhtigIssueTracker.Enumerations;
    using global::BuhtigIssueTracker.Utils;

    #endregion

    public class Issue
    {
        private string description;

        private string title;

        public Issue(string title, string description, IssuePriority priority, List<string> tags)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException(Messages.TextMustBe3Symbols);
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(Messages.TextMustBe5Symbols);
                }

                this.description = value;
            }
        }

        public IssuePriority Priority { get; set; }

        public IList<string> Tags { get; set; }

        public IList<Comment> Comments { get; set; }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            var issue = new StringBuilder();
            issue.AppendLine(this.Title)
                .AppendFormat(Messages.Priority, this.GetPriorityAsString())
                .AppendLine()
                .AppendLine(this.Description);
            if (this.Tags.Count > 0)
            {
                issue.AppendFormat(Messages.Tags, string.Join(",", this.Tags.OrderBy(t => t))).AppendLine();
            }

            if (this.Comments.Count > 0)
            {
                issue.AppendFormat(
                    Messages.Comments, 
                    Environment.NewLine, 
                    string.Join(Environment.NewLine, this.Comments)).AppendLine();
            }

            return issue.ToString().Trim();
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case IssuePriority.Showstopper:
                    return "****";
                case IssuePriority.High:
                    return "***";
                case IssuePriority.Medium:
                    return "**";
                case IssuePriority.Low:
                    return "*";
                default:
                    throw new InvalidOperationException(Messages.IvalidPrioroty);
            }
        }
    }
}