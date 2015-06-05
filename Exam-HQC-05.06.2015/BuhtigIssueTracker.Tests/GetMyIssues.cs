using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using BuhtigIssueTracker.Core;
    using BuhtigIssueTracker.Enumerations;
    using BuhtigIssueTracker.Models;

    [TestClass]
    public class GetMyIssues
    {
        private IssueTracker issueTracker;
        [TestInitialize]
        public void InitialStuff()
        {
            this.issueTracker = new IssueTracker(new BuhtigIssueTrackerData());
        }

        [TestMethod]
        public void GetMyIssuesWithoudLoggedUser_ShouldReturnCorrectMessage()
        {
            var output = this.issueTracker.GetMyIssues();
            Assert.AreEqual("There is no currently logged in user", output);
        }

        [TestMethod]
        public void GetMyIssuesWithoutMessages_ShouldReturnCorrectMessage()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
             this.issueTracker.LoginUser("admin", "123");
            // var output = this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
            var output = this.issueTracker.GetMyIssues();
            Assert.AreEqual("No issues", output);
        }

        [TestMethod]
        public void GetMyIssues_ShouldReturnCorrectMessagePrintout()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            this.issueTracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, new[] { "new", "issue" });
            this.issueTracker.CreateIssue("Another issue", "This is another new issue", IssuePriority.Medium, new[] { "new", "issue", "another" });
            var output = this.issueTracker.GetMyIssues();
            var expected =
                "New issue\r\nPriority: ***\r\nThis is a new issue\r\nTags: issue,new\r\nAnother issue\r\nPriority: **\r\nThis is another new issue\r\nTags: another,issue,new";
            Assert.AreEqual(expected, output);
        }
    }
}
