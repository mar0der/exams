namespace BuhtigIssueTracker.Models
{
    #region

    using System;
    using System.Text;

    using global::BuhtigIssueTracker.Utils;

    #endregion

    public class Comment
    {
        private string commentText;

        public Comment(User commentAuthor, string commentText)
        {
            this.CommentAuthor = commentAuthor;
            this.CommentText = commentText;
        }

        public User CommentAuthor { get; set; }

        public string CommentText
        {
            get
            {
                return this.commentText;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException(Messages.TextMustBe2Symbols);
                }

                this.commentText = value;
            }
        }

        public override string ToString()
        {
            var output =
                new StringBuilder().AppendLine(this.CommentText)
                    .AppendFormat("-- {0}", this.CommentAuthor.Username)
                    .AppendLine()
                    .ToString()
                    .Trim();
            return output;
        }
    }
}