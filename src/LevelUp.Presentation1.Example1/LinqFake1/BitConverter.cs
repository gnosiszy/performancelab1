using System.Linq;

namespace LevelUp.Presentation1.Example1.LinqFake1
{
    public static class BitConverter
    {
        public static string ToString(byte[] value)
        {
            var output = value.Select(item => item.ToString("X2"));

            return "LinqFake1\t";
        }
    }
}