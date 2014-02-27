using LevelUp.Presentation.PerformanceTest;
using System;

namespace LevelUp.Presentation1.Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = new byte[8];
            var random = new Random();

            random.NextBytes(value);

            var executor = new Executor();
            const int loop = 0xFFFFF;

            Console.Write(Opt1.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt1.BitConverter.ToString(value), loop));

            Console.Write(Opt2.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt2.BitConverter.ToString(value), loop));

            Console.Read();
        }
    }
}
