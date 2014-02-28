using LevelUp.Presentation.PerformanceTest;
using System;

namespace LevelUp.Presentation1.Example2
{
    class Program
    {
        static void Main()
        {
            var executor = new Executor();
            const int loop = 0xFFFFFFF;

            Console.WriteLine("Comum {0}", executor.Loop(() => { }, loop));
            Console.WriteLine("Optmz {0}", executor.OptmzLoop(() => { }, loop));

            Console.Read();
        }
    }
}
