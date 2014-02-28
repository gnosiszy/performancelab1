using System;
using System.Linq;

namespace LevelUp.Presentation1.Example1.Linq
{
    public static class BitConverter
    {
        public static string ToString(byte[] value)
        {
            return String.Join("-", value.Select(item => item.ToString("X2")).ToArray());
        }
    }
}