using LevelUp.Presentation.PerformanceTest;
using System;

namespace LevelUp.Presentation1.Example1
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
                Mono.BitConverter.ToString,
                MonoOptmz.BitConverter.ToString,
                LinqFake1.BitConverter.ToString,
                LinqFake2.BitConverter.ToString,
                Linq.BitConverter.ToString,
                Optmz1.BitConverter.ToString,
                Optmz2.BitConverter.ToString,
                Optmz3.BitConverter.ToString,
                Unsafe.BitConverter.ToString,
            };

            foreach (var action in actions)
            {
                var toString = action;

                Console.ForegroundColor = ConsoleColor.DarkRed;

                // ReSharper disable once PossibleNullReferenceException
                Console.WriteLine(action.Method.DeclaringType.FullName);

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write('\t');
                Console.Write(toString(value));
                Console.Write('\t');
                Console.Write(executor.OptmzLoop(() => toString(value), loop));
                Console.Write('\t');
                Console.WriteLine(executor.TimeLoop(() => toString(value), 1000));
            }

            Console.Read();
        }
    }
}
