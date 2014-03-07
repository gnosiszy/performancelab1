using System;

namespace LevelUp.Presentation1.Example1.Unsafe3
{
    public static class BitConverter
    {
        const char AlphaValue = (char)('A' - 10);

        public static string ToString(byte[] value)
        {
            var length = value.Length;
            var output = new String('\0', length * 3 - 1);

            unsafe
            {
                fixed (char* c = output)
                {
                    var c2 = c;

                    fixed (byte* b = value)
                    {
                        var b2 = b;

                        for (var i = 0; i < length; i++)
                        {
                            if (i != 0)
                            {
                                *c2++ = '-';
                            }

                            var high = *b2 >> 4;
                            var low = *b2++ & 0x0F;

                            high += high < 10 ? '0' : AlphaValue;
                            low += low < 10 ? '0' : AlphaValue;

                            *c2++ = (char)high;

                            *c2++ = (char)low;
                        }
                    }
                }
            }

            return output;
        }
    }
}