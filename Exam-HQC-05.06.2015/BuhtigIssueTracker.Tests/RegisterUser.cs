namespace UnitTestProject1
{
    #region

    using BuhtigIssueTracker.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion

    [TestClass]
    public class RegisterUser
    {
        private IssueTracker issueTracker;

        [TestInitialize]
        public void CreateIssueTracker()
        {
            this.issueTracker = new IssueTracker();
        }

        [TestMethod]
        public void SuccesfullUserRegistration_ShouldPrintCorrectMessage()
        {
            var output = this.issueTracker.RegisterUser("admin", "123", "123");
            Assert.AreEqual("User admin registered successfully", output);
        }

        [TestMethod]
        public void NotMatchingPasswords_ShouldPrintCorrectMessage()
        {
            var output = this.issueTracker.RegisterUser("admin", "123", "1234");
            Assert.AreEqual("The provided passwords do not match", output);
        }

        [TestMethod]
        public void CreatingSameUserTwise_ShouldPrintCorrectMessage()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            var output = this.issueTracker.RegisterUser("admin", "123", "123");
            Assert.AreEqual("A user with username admin already exists", output);
        }

        [TestMethod]
        public void UserAlreadyLoggedIn_ShouldPrintCorrectMessage()
        {
            this.issueTracker.RegisterUser("admin", "123", "123");
            this.issueTracker.LoginUser("admin", "123");
            var output = this.issueTracker.RegisterUser("admin", "123", "123");
            Assert.AreEqual("There is already a logged in user", output);
        }
    }
}