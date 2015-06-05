namespace BuhtigIssueTracker.Interfaces
{
    #region

    using global::BuhtigIssueTracker.Enumerations;

    #endregion

    /// <summary>
    ///     Defines issue tracker. It can register, login and logout users. T
    ///     The tracker contains a set of commands for:
    ///     adding and removing issues. Adding comments to issues
    ///     Getting users own issues and own comments.
    ///     Search by Tags.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        ///     Register user to the tracker by given username, password and confirm password
        /// </summary>
        /// <param name="username">The desired username</param>
        /// <param name="password">The users desired password</param>
        /// <param name="confirmPassword">The users confirmation of desired password</param>
        /// <returns>
        ///     In case of success, the action returns "User USERNAME registered successfully"
        ///     If there is already a logged in user, the action returns "There is already a logged in user"
        ///     If the two passwords do not match, the action returns The provided passwords do not match
        ///     If the username is already taken, the action returns "A user with username USERNAME already exists"
        /// </returns>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        ///     Loggs in the user by his username and password. Logins a user in the application.
        ///     After login, they become the currently active user.
        /// </summary>
        /// <param name="username">Users username</param>
        /// <param name="password">Users password</param>
        /// <returns>
        ///     In case of success, the action returns User
        ///     USERNAME
        ///     logged in successfully
        ///     If there is already a logged in user, the action returns There is already a logged in user
        ///     If there is no user with the provided username, the action returns
        ///     "A user with username USERNAME does not exist"
        ///     If the password is invalid, the action returns "The password is invalid for user USERNAME"
        /// </returns>
        string LoginUser(string username, string password);

        /// <summary>
        ///     The method loggs out currently logged user
        /// </summary>
        /// <returns>
        ///     In case of success, the action returns "User USERNAME logged out successfully"
        ///     If there is no logged in user, the action returns "There is no currently logged in user"
        /// </returns>
        string LogoutUser();

        /// <summary>
        ///     Creates a new issue. Assigns the current user as its author. Gives it an ID automatically.
        ///     If the issue title is less than 3 symbols long, or if the issue description is less than
        ///     5 symbols long, the system throws an ArgumentException with an appropriate message
        /// </summary>
        /// <param name="title">Issues title</param>
        /// <param name="description">Issues description</param>
        /// <param name="priority">Issiues prioroty</param>
        /// <param name="tags">Pile ("|") separated tags</param>
        /// <returns>
        ///     In case of success, the action returns "Issue ID created successfully"
        ///     If there is no logged in user, the action returns "There is no currently logged in user"
        /// </returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        ///     Removes an issue given by the specified ID.
        /// </summary>
        /// <param name="issueId">Issues id</param>
        /// <returns>
        ///     In case of success, the action returns "Issue ID removed"
        ///     If there is no logged in user, the action returns "There is no currently logged in user"
        ///     If the issue ID is invalid (i. e., does not exist in the database), the action returns
        ///     "There is no issue with
        ///     <id>
        ///         ID"
        ///         If the issue does not belong to the currently logged in user, the action returns
        ///         "The issue with ID ID does not belong to user CURRENT_USER_USERNAME"
        /// </returns>
        string RemoveIssue(int issueId);

        /// <summary>
        ///     Adds a comment to the issue given by the specified ID.
        /// </summary>
        /// <param name="issueId">Issues Id</param>
        /// <param name="commentText">Comments text</param>
        /// <returns>
        ///     If the text is less than 2 symbols long, the system throws an ArgumentException with an appropriate message.
        ///     In case of success, the action returns "Comment added successfully to issue  ID"
        ///     If there is no logged in user, the action returns "There is no currently logged in user"
        ///     If the issue ID is invalid (i. e., does not exist in the database), the action returns
        ///     "There is no issue with ID <id>"
        /// </returns>
        string AddComment(int issueId, string commentText);

        /// <summary>
        ///     Prints the issues created by the currently active user.
        /// </summary>
        /// <returns>
        ///     In case of success, the action returns the issues sorted by priority (in descending order) first, and by title (in
        ///     alphabetical order) next. Each issue is printed in a user-friendly way, each on its own line. Refer to the sample
        ///     outputs to see how exactly an issue should be formatted.
        ///     If there are no issues, the action returns No issues
        ///     If there is no logged in user, the action returns "There is no currently logged in user"
        /// </returns>
        string GetMyIssues();

        /// <summary>
        ///     Prints the comments created by the currently active user.
        /// </summary>
        /// <returns>
        ///     In case of success, the action returns the comments sorted by time of adding to the application database. Each
        ///     comment is printed in a user-friendly way, each on its own line. Refer to the sample outputs to see how exactly a
        ///     comment should be formatted.
        ///     If there are no comments, the action returns "No comments"
        ///     If there is no logged in user, the action returns "There is no currently logged in user"
        /// </returns>
        string GetMyComments();

        /// <summary>
        ///     Searches for issues containing one or more of the provided tags.
        /// </summary>
        /// <param name="tags">Pipe spaced ("|") taglist</param>
        /// <returns>
        ///     If an issue matches several tags, it is included only once in the search results. The tags (if there are two or
        ///     more) are separated by a single pipe sign ("|").
        ///     In case of success, the action returns the issues sorted by priority (in descending order) first, and by title (in
        ///     alphabetical order) next. Each issue is printed in a user-friendly way, each on its own line.
        ///     If there are no tags provided, the action returns "There are no tags provided"
        ///     If there are no matching issues, the action returns "There are no issues matching the tags provided"
        /// </returns>
        string SearchForIssues(string[] tags);
    }
}