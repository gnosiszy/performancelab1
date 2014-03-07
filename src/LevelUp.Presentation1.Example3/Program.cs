using LevelUp.Presentation.PerformanceTest;
using System;

namespace LevelUp.Presentation1.Example3
{
    class Program
    {
        static void Main()
        {
            const int loop = 0xFFFFFF;
            const string n = "34985";

            var executor = new Executor();

            var actions = new Func<int>[]
            {
                () => Convert.ToInt32(n),
                () => int.Parse(n),
            };

            foreach (var action in actions)
            {
                var run = action;

                Console.Write(executor.OptmzLoop(() => run(), loop));
                Console.Write('\t');
                Console.Write(executor.AsyncLoop(() => run(), loop));
                Console.Write('\t');
                Console.WriteLine(executor.TimeLoop(() => run(), 1000));
            }

            Console.Read();
        }
    }
}
