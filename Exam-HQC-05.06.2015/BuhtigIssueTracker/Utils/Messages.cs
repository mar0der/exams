namespace BuhtigIssueTracker.Utils
{
    public static class Messages
    {
        public const string ThereIsLoggedUser = "There is already a logged in user";

        public const string PasswordsNotMatch = "The provided passwords do not match";

        public const string UserAlreadyExists = "A user with username {0} already exists";

        public const string UserRegisteredSuccessfully = "User {0} registered successfully";

        public const string UserDoesNotExists = "A user with username {0} does not exist";

        public const string PasswordIsInvalidForUser = "The password is invalid for user {0}";

        public const string UserLoggedSuccessfully = "User {0} logged in successfully";

        public const string NoLoggedUser = "There is no currently logged in user";

        public const string UserLoggedOutSuccessfully = "User {0} logged out successfully";

        public const string IssueCreatedSuccessfully = "Issue {0} created successfully";

        public const string NoIssueWithId = "There is no issue with ID {0}";

        public const string CommentAddedToIssue = "Comment added successfully to issue {0}";

        public const string IssueDoesNotBelongToUserWithId = "The issue with ID {0} does not belong to user {1}";

        public const string IssueWithIdRemoved = "Issue {0} removed";

        public const string NoIssues = "No issues";

        public const string IvalidActionWithName = "Invalid action: {0}";

        public const string NoComment = "No comments";

        public const string NoTagsProvided = "There are no tags provided";

        public const string NoIssuesMatchingTheTags = "There are no issues matching the tags provided";

        public const string Priority = "Priority: {0}";

        public const string Tags = "Tags: {0}";

        public const string Comments = "Comments:{0}{1}";

        public const string IvalidPrioroty = "The priority is invalid";

        public const string TextMustBe2Symbols = "The text must be at least 2 symbols long";

        public const string TextMustBe3Symbols = "The title must be at least 3 symbols long";

        public const string TextMustBe5Symbols = "The description must be at least 5 symbols long";
    }
}