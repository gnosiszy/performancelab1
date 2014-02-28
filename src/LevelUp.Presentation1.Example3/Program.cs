using LevelUp.Presentation.PerformanceTest;
using System;

namespace LevelUp.Presentation1.Example3
{
    class Program
    {
        static void Main()
        {
            var value = new byte[8];
            var random = new Random();

            random.NextBytes(value);

            var executor = new Executor();
            const int loop = 0xFFFFF;

            var actions = new Func<byte[], string>[]
            {
                BitConverter.ToString,
                Opt1.BitConverter.ToString,
                Opt2.BitConverter.ToString,
            };

            foreach (var action in actions)
            {
                var toString = action;

                Console.Write(toString(value));
                Console.Write('\t');
                Console.WriteLine(executor.OptmzLoop(() => toString(value), loop));
            }

            Console.Read();
        }
    }
}
