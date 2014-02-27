using System;

namespace Opt1
{
    public static class BitConverter
    {
        const char AlphaValue = (char)('A' - 10);

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

                output[index + 1] = (char)high;
                output[index + 2] = (char)low;
            }

            return new String(output);
        }
    }
}