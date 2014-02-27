using System;

namespace Opt2
{
    public static class BitConverter
    {
        const char AlphaValue = (char)('A' - 10);

        private static char ToChar(int value)
        {
            if (value < 10)
            {
                value += '0';
            }
            else
            {
                value += AlphaValue;
            }

            return (char)value;
        }

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

                output[index + 1] = ToChar(ch >> 4);
                output[index + 2] = ToChar(ch & 0x0F);
            }

            return new String(output);
        }
    }
}