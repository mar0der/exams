namespace UnitTestProject1
{
    using BuhtigIssueTracker.Core;
    using BuhtigIssueTracker.Enumerations;
    using BuhtigIssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MyComments
    {
        private IssueTracker issueTracker;

        [TestInitialize]
        public void InitialStuff()
        {
            this.issueTracker = new IssueTracker(new BuhtigIssueTrackerData());
        }

        [TestMethod]
        public void TestMethod1()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
            this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
            this.issueTracker.AddComment(1, "New comment");
            this.issueTracker.AddComment(1, "Another comment");
            this.issueTracker.AddComment(1, "New comment");
            this.issueTracker.AddComment(2, "Another comment");
            var output = this.issueTracker.GetMyComments();
            var expected =
                "New comment\r\n-- admin\r\nAnother comment\r\n-- admin\r\nNew comment\r\n-- admin\r\nAnother comment\r\n-- admin";
            Assert.AreEqual(expected, output);
        }
    }
}
