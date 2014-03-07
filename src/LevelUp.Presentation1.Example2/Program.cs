using LevelUp.Presentation.PerformanceTest;
using System;
using System.Text;

namespace LevelUp.Presentation1.Example2
{
    class Program
    {
        static void Main()
        {
            var executor = new Executor();
            const int loop = 0xFFFFFF;
            const string name = "L. Freneda";
            var actions = new Func<string>[]
            {
                () =>
                {
                    var builder = new StringBuilder();

                    unsafe
                    {
                        // ReSharper disable once InconsistentNaming
                        fixed (char* name_c = name)
                        {
                            var length = name.Length;
                            var seeker = name_c;
                            var i = -1;

                            while (++i < length)
                            {
                                builder.Append(*(seeker++));
                            }
                        }
                    }

                    return builder.ToString();
                },
                () =>
                {
                    var builder = new StringBuilder();

                    unsafe
                    {
                        // ReSharper disable once InconsistentNaming
                        fixed (char* name_c = name)
                        {
                            var length = name.Length;
                            var seeker = name_c;

                            for (var i = 0; i < length; i++)
                            {
                                builder.Append(*(seeker++));
                            }
                        }
                    }

                    return builder.ToString();
                },
                () =>
                {
                    var builder = new StringBuilder();

                    var length = name.Length;

                    for (var i = 0; i < length; i++)
                    {
                        builder.Append(name[i]);
                    }

                    return builder.ToString();
                },
            };

            foreach (var action in actions)
            {
                var run = action;

                Console.WriteLine(run());
                Console.WriteLine("Comum {0}", executor.Loop(() => run(), loop));
                Console.WriteLine("Optmz {0}", executor.OptmzLoop(() => run(), loop));
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
