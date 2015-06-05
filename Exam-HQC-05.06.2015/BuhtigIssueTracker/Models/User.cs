namespace BuhtigIssueTracker.Models
{
    #region

    using global::BuhtigIssueTracker.Utils;

    #endregion

    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.PasswordHash = PasswordHasher.HashPassword(password);
        }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}