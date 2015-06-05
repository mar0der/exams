using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using BuhtigIssueTracker.Core;
    using BuhtigIssueTracker.Enumerations;
    using BuhtigIssueTracker.Models;
    using BuhtigIssueTracker.Utils;

    [TestClass]
    public class SearchForIssues
    {
        private IssueTracker issueTracker;

        [TestInitialize]
        public void InitialStuff()
        {
            this.issueTracker = new IssueTracker(new BuhtigIssueTrackerData());
        }

        [TestMethod]
        public void SearchWithNoTagsProvieded_ShoulReturnCorrectMessage()
        {
            string[] tags = new string[0];
            var output = this.issueTracker.SearchForIssues(tags);

            Assert.AreEqual(Messages.NoTagsProvided, output);
        }

        [TestMethod]
        public void SearchWithUnUsedTags_ShoulReturnCorrectMessage()
        {

            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "tag1", "tag2" });

            string[] tags = new string[2];
            tags[0] = "tag3";
            var output = this.issueTracker.SearchForIssues(tags);
            Assert.AreEqual(Messages.NoIssuesMatchingTheTags, output);
            tags[1] = "tag4";
            output = this.issueTracker.SearchForIssues(tags);
            Assert.AreEqual(Messages.NoIssuesMatchingTheTags, output);
        }

        [TestMethod]
        public void SearchWithUsedTag_ShouldReturnCorrectIssues()
        {

            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            this.issueTracker.CreateIssue("Another issue", "This is another new issue", IssuePriority.Medium, new[] { "new", "issue", "another" });
            this.issueTracker.CreateIssue("BBB", "This is a new issue", IssuePriority.High, new[] { "new", "issue" });
            this.issueTracker.CreateIssue("AAA", "This is a new issue", IssuePriority.High, new[] { "new", "issue" });
            string[] tags = { "issue" };
            var output = this.issueTracker.SearchForIssues(tags);
            //checks for the right order of the results
            var expected =
                "AAA\r\nPriority: ***\r\nThis is a new issue\r\nTags: issue,new\r\nBBB\r\nPriority: ***\r\nThis is a new issue\r\nTags: issue,new\r\nAnother issue\r\nPriority: **\r\nThis is another new issue\r\nTags: another,issue,new";
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void SearchWith2UsedTags_ShouldReturnOnlyOneIssue()
        {

            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            this.issueTracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, new[] { "new", "issue" });
            string[] tags = { "issue", "new" };
            var output = this.issueTracker.SearchForIssues(tags);

            var expected =
            "New issue\r\nPriority: ***\r\nThis is a new issue\r\nTags: issue,new";
            Assert.AreEqual(expected, output);
        }
    }
}
