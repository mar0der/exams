namespace BuhtigIssueTracker.Core
{
    #region

    using System;

    using global::BuhtigIssueTracker.Interfaces;
    using global::BuhtigIssueTracker.Models;

    #endregion

    public class Engine : IEngine
    {
        private readonly Dispatcher dispatcher;

        public Engine(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public Engine()
            : this(new Dispatcher())
        {
        }

        public void Run()
        {
            while (true)
            {
                var url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endPoint = new Endpoint(url);
                        var output = this.dispatcher.DispatchAction(endPoint);
                        Console.WriteLine(output);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}