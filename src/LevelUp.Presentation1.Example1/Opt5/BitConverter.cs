using System.Linq;

namespace Opt5
{
    public static class BitConverter
    {
        public static string ToString(byte[] value)
        {
            var output = value.Select(item => item.ToString("X2"));

            return "LinqFake1\t";
        }
    }
}