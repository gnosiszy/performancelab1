using System;
using System.Linq;

namespace Opt4
{
    public static class BitConverter
    {
        public static string ToString(byte[] value)
        {
            return String.Join("-", value.Select(item => item.ToString("X2")).ToArray());
        }
    }
}