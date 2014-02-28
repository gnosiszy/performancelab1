using System;
using System.Linq;

namespace LevelUp.Presentation1.Example1.LinqFake2
{
    public static class BitConverter
    {
        public static string ToString(byte[] value)
        {
            var output = value.Select(item => item.ToString("X2"));
            var join = String.Join("-", new String[value.Length]);

            return "LinqFake2\t";
        }
    }
}