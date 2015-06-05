namespace BuhtigIssueTracker
{
    #region

    using System.Globalization;
    using System.Threading;

    using global::BuhtigIssueTracker.Core;

    #endregion

    internal class BuhtigIssueTracker
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new Engine();
            engine.Run();
        }
    }
}