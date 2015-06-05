namespace BuhtigIssueTracker.Utils
{
    #region

    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    #endregion

    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return string.Join(
                string.Empty, 
                SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)).Select(x => x.ToString()));
        }
    }
}