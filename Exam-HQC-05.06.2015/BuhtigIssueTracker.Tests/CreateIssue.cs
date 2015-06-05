using BuhtigIssueTracker.Core;
using BuhtigIssueTracker.Enumerations;
using BuhtigIssueTracker.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    #region

    using System;

    using BuhtigIssueTracker.Core;
    using BuhtigIssueTracker.Enumerations;
    using BuhtigIssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion


    [TestClass]
    public class CreateIssue
    {
        private IssueTracker issueTracker;

        [TestInitialize]
        public void InitialStuff()
        {
            this.issueTracker = new IssueTracker(new BuhtigIssueTrackerData());
        }

        [TestMethod]
        public void CreateIssue_ShouldShouldReturnCorrectMessage()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            var output = this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
            var issueId = (this.issueTracker.Data.NextIssueId - 1).ToString();
            Assert.AreEqual("Issue " + issueId + " created successfully", output);
        }

    [TestMethod]
        public void CreateIssueWithoudLoggedUser_ShouldShouldReturnCorrectMessage()
        {
            var output = this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
            var issueId = (this.issueTracker.Data.NextIssueId - 1).ToString();
            Assert.AreEqual("There is no currently logged in user", output);
        }

    [TestMethod]
    public void Create2Issues_ShouldShouldIncrementCounterCorreclty()
    {
        this.issueTracker.RegisterUser("admin", "123", "123");
        this.issueTracker.LoginUser("admin", "123");
        this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
        this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
        Assert.AreEqual(3, this.issueTracker.Data.NextIssueId);
        this.issueTracker.RemoveIssue(2);
        Assert.AreEqual(3, this.issueTracker.Data.NextIssueId);
        this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
        Assert.AreEqual(4, this.issueTracker.Data.NextIssueId);
    }

        [TestMethod]
        public void CreateIssue_ShouldHave1IssueInTheDictionary()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            var output = this.issueTracker.CreateIssue("issue1", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
            Assert.AreEqual(1, this.issueTracker.Data.IssuesById.Count);
            Assert.AreEqual(1, this.issueTracker.Data.IssuesByUsername.Count);
            Assert.AreEqual(2, this.issueTracker.Data.TagsIssues.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssueWithTitleOnly3Letters_ShouldThrowExeption()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            var output = this.issueTracker.CreateIssue("12", "issueDescr", IssuePriority.High, new[] { "af", "sf" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssueWithDescriptionOnly4Letters_ShouldThrowExeption()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            var output = this.issueTracker.CreateIssue("1234", "1234", IssuePriority.High, new[] { "af", "sf" });
        }
    }
}

