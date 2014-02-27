using System;
using System.Diagnostics;

namespace LevelUp.Presentation.PerformanceTest
{
    public class Executor
    {
        public TimeSpan Loop(Action action, long loops)
        {
            var watcher = new Stopwatch();

            watcher.Start();

            for (var i = 0; i < loops; i++)
            {
                action();
            }

            watcher.Stop();

            return watcher.Elapsed;
        }

        public TimeSpan OptmzLoop(Action action, long loops)
        {
            var watcher = new Stopwatch();

            watcher.Start();

            var i = 0;
            var optmzLoop = loops - (loops % 8);

            for (; i < optmzLoop; i += 8)
            {
                action();
                action();
                action();
                action();
                action();
                action();
                action();
                action();
            }

            for (; i < loops; i++)
            {
                action();
            }

            watcher.Stop();

            return watcher.Elapsed;
        }
    }
}
