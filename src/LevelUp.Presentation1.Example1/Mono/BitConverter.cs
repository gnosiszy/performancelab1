using System;
using System.Text;

namespace LevelUp.Presentation1.Example1.Mono
{
    public
    static
    class BitConverter
    {
        public static string ToString(byte[] value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return ToString(value, 0, value.Length);
        }

        public static string ToString(byte[] value, int startIndex)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return ToString(value, startIndex, value.Length - startIndex);
        }

        public static string ToString(byte[] value, int startIndex, int length)
        {
            if (value == null)
                throw new ArgumentNullException("byteArray");

            // The 4th and last clause (start_index >= value.Length)
            // was added as a small fix to a very obscure bug.
            // It makes a small difference when start_index is
            // outside the range and length==0. 
            if (startIndex < 0 || startIndex >= value.Length)
            {
                // special (but valid) case (e.g. new byte [0])
                if ((startIndex == 0) && (value.Length == 0))
                    return String.Empty;
                throw new ArgumentOutOfRangeException("startIndex", "Index was"
                    + " out of range. Must be non-negative and less than the"
                    + " size of the collection.");
            }

            if (length < 0)
                throw new ArgumentOutOfRangeException("length",
                    "Value must be positive.");

            // note: re-ordered to avoid possible integer overflow
            if (startIndex > value.Length - length)
                throw new ArgumentException("startIndex + length > value.Length");

            if (length == 0)
                return string.Empty;

            StringBuilder builder = new StringBuilder(length * 3 - 1);
            int end = startIndex + length;

            for (int i = startIndex; i < end; i++)
            {
                if (i > startIndex)
                    builder.Append('-');

                char high = (char)((value[i] >> 4) & 0x0f);
                char low = (char)(value[i] & 0x0f);

                if (high < 10)
                    high += '0';
                else
                {
                    high -= (char)10;
                    high += 'A';
                }

                if (low < 10)
                    low += '0';
                else
                {
                    low -= (char)10;
                    low += 'A';
                }
                builder.Append(high);
                builder.Append(low);
            }

            return builder.ToString();
        }
    }
}