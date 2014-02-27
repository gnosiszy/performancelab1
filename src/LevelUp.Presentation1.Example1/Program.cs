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
            const int loop = 0xFFFFFF;

            Console.Write(BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => BitConverter.ToString(value), loop));

            Console.Write(Mono.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Mono.BitConverter.ToString(value), loop));

            Console.Write(Opt1.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt1.BitConverter.ToString(value), loop));
            
            Console.Write(Opt2.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt2.BitConverter.ToString(value), loop));

            Console.Write(Opt3.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt3.BitConverter.ToString(value), loop));

            Console.Write(Opt4.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt4.BitConverter.ToString(value), loop));

            Console.Write(Opt5.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt5.BitConverter.ToString(value), loop));

            Console.Write(Opt6.BitConverter.ToString(value));
            Console.Write('\t');
            Console.WriteLine(executor.Loop(() => Opt6.BitConverter.ToString(value), loop));

            Console.Read();
        }
    }
}
