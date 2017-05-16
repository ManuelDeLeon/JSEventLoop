using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JSEventLoop
{
    static class Engine
    {
        private static List<Action> pendingActions = new List<Action>();
        private static List<Action> pendingJobs = new List<Action>();

        public static void run(Action action)
        {
            action();
            runPending();
        }

        private static void runPending()
        {
            while (pendingActions.Any() || pendingJobs.Any())
            {
                runJobs();
                Thread.Sleep(4);
                var actionsToRun = pendingActions.ToList();
                pendingActions.Clear();
                foreach (var action in actionsToRun)
                {
                    action();
                }
            }
        }

        private static void runJobs()
        {
            var jobsToRun = pendingJobs.ToList();
            pendingJobs.Clear();
            foreach (var job in jobsToRun)
            {
                job();
            }
        }

        public static void setTimeout(Action action, int interval)
        {
            var startTime = DateTime.Now.AddMilliseconds(interval);
            setTimeout(action, startTime);
        }

        private static void setTimeout(Action action, DateTime startTime)
        {
            Action timeoutAction = () =>
            {
                if (DateTime.Now >= startTime)
                {
                    action();
                }
                else
                {
                    setTimeout(action, startTime);
                }
            };
            pendingActions.Add(timeoutAction);
        }


        public static void setImmediate(Action action)
        {
            pendingJobs.Add(action);
        }

        
    }
}
