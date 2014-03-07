using LevelUp.Presentation.PerformanceTest;
using System;
using System.Linq;

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
                LinqFake3.BitConverter.ToString,
                Linq.BitConverter.ToString,
                Optmz1.BitConverter.ToString,
                Optmz2.BitConverter.ToString,
                Optmz3.BitConverter.ToString,
                Unsafe1.BitConverter.ToString,
                Unsafe2.BitConverter.ToString,
                Unsafe3.BitConverter.ToString,
            };

            // ReSharper disable once PossibleNullReferenceException
            foreach (var order in actions.Select(toString => new BitConverterOrder()
            {
                Value = toString(value),
                Name = toString.Method.DeclaringType.FullName,
                Loop = executor.Loop(() => toString(value), loop),
                AsyncLoop = executor.AsyncLoop(() => toString(value), loop),
                OptmzLoop = executor.OptmzLoop(() => toString(value), loop),
                TimeLoop = executor.TimeLoop(() => toString(value), 1000),
            })
                .OrderBy(item => item.TimeLoop)
            )
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine(order.Name);

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write('\t');
                Console.Write(order.Value);
                Console.Write('\t');
                Console.Write('\t');
                Console.Write(order.Loop);
                Console.Write('\t');
                Console.Write(order.AsyncLoop);
                Console.Write('\t');
                Console.Write(order.OptmzLoop);
                Console.Write('\t');
                Console.WriteLine(order.TimeLoop);
            }

            Console.Read();
        }
    }

    class BitConverterOrder
    {
        public string Value;
        public string Name;
        public TimeSpan Loop;
        public TimeSpan AsyncLoop;
        public TimeSpan OptmzLoop;
        public long TimeLoop;
    }
}
