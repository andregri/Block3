using System;
using System.Text;

namespace Exercise02
{
    public class LargeNumber
    {
        static void Main(string[] args)
        {
        }

        // if 'num' is smaller than 'newSize', add a padding of zeroes to 'num';
        // else return 'num' unmodified.
        public static string Extend(string num, long newSize)
        {
            StringBuilder newNum;
            long oldSize = num.Length;

            if (oldSize >= newSize)
            {
                return num;
            }
            else
            {
                newNum = new StringBuilder(num);

                for (long i = oldSize; i < newSize; i++)
                {
                    newNum.Append('0');
                }
            }

            return newNum.ToString();
        }
    }
}
