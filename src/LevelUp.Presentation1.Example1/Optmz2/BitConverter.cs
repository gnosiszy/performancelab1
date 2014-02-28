using System;

namespace LevelUp.Presentation1.Example1.Optmz2
{
    public static class BitConverter
    {
        const string HexValue = "0123456789ABCDEF";

        public static string ToString(byte[] value)
        {
            var length = value.Length;
            var output = new char[length * 3 - 1];

            for (var i = 0; i < length; i++)
            {
                var index = i * 3 - 1;

                if (i > 0)
                {
                    output[index] = '-';
                }

                var ch = value[i];
                var high = ch >> 4;
                var low = ch & 0x0F;

                output[index + 1] = HexValue[high];
                output[index + 2] = HexValue[low];
            }

            return new String(output);
        }
    }
}