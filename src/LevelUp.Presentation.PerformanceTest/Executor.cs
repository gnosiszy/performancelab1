using System;
using System.Diagnostics;
using System.Threading;

namespace LevelUp.Presentation.PerformanceTest
{
    public class Executor
    {
        public int TimeLoop(Action action, double time)
        {
            return TimeLoop(action, TimeSpan.FromMilliseconds(time));
        }

        public int TimeLoop(Action action, TimeSpan time)
        {
            var i = 0;
            var abort = false;
            var thread = new Thread(() =>
            {
                while (!abort)
                {
                    action();
                    ++i;
                }
            });

            thread.Start();
            Thread.Sleep(time);
            abort = true;

            return i;
        }

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

        public TimeSpan AsyncLoop(Action action, long loops)
        {
            return AsyncLoop(action, loops, 4);
        }

        public TimeSpan AsyncLoop(Action action, long loops, int threadCount)
        {
            var watcher = new Stopwatch();

            watcher.Start();

            var threads = new Thread[threadCount];
            var optmzLoop = loops - (loops % threadCount);
            var length = optmzLoop / threadCount;

            for (var i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (var j = 0; j < length; j++)
                    {
                        action();
                    }
                });

                threads[i].Start();
            }

            for (var i = 0; i < threadCount; i++)
            {
                threads[i].Join();
            }

            for (var i = optmzLoop; i < loops; i++)
            {
                action();
            }

            watcher.Stop();

            return watcher.Elapsed;
        }
    }
}
