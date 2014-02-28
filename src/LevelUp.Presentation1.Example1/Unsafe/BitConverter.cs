using System;

namespace LevelUp.Presentation1.Example1.Unsafe
{
    public static class BitConverter
    {
        const char AlphaValue = (char)('A' - 10);

        public unsafe static string ToString(byte[] value)
        {
            var length = value.Length;
            var output = new char[length * 3 - 1];

            fixed (char* c = &(output[0]))
            {
                var c2 = c;

                fixed (byte* b = &(value[0]))
                {
                    var b2 = b;
                    for (var i = 0; i < length; i++)
                    {
                        if (i > 0)
                        {
                            *c2 = '-';
                            c2++;
                        }

                        var high = *b2 >> 4;
                        var low = *b2 & 0x0F;

                        b2++;

                        if (high < 10)
                        {
                            high += '0';
                        }
                        else
                        {
                            high += AlphaValue;
                        }

                        if (low < 10)
                        {
                            low += '0';
                        }
                        else
                        {
                            low += AlphaValue;
                        }

                        *c2 = (char)high;
                        c2++;

                        *c2 = (char)low;
                        c2++;
                    }
                }
            }

            return new String(output);
        }
    }
}