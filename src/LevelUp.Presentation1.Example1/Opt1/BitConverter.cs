using System.Text;

namespace Opt1
{
    public static class BitConverter
    {
        public static string ToString(byte[] value)
        {
            var length = value.Length;
            var builder = new StringBuilder(length * 3 - 1);

            for (int i = 0; i < length; i++)
            {
                if (i > 0)
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