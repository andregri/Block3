using System;
using System.Text;

namespace Exercise02
{
    //the least significant digit is at index 0
    public class LargeNumber
    {
        private static Random rand = new Random();

        public static string Random(long size)
        {
            StringBuilder num = new StringBuilder();

            for (int i = 0; i < size - 1; i++)
            {
                num.Append(rand.Next(0, 10));
            }

            num.Append(rand.Next(1, 10));

            return num.ToString();
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

        public static string Sum(string a, string b)
        {
            long sizeMax = Math.Max(a.Length, b.Length);
            string num1 = Extend(a, sizeMax);
            string num2 = Extend(b, sizeMax);

            StringBuilder result = new StringBuilder();

            //sum first digits
            int op1 = num1[0] - 48;
            int op2 = num2[0] - 48;
            int partialSum = op1 + op2;
            result.Append(partialSum % 10);
            int carryOut = partialSum / 10;

            //sum other digits
            for (int i = 1; i < sizeMax; i++)
            {
                op1 = num1[i] - 48;
                op2 = num2[i] - 48;
                partialSum = op1 + op2 + carryOut;

                result.Append(partialSum % 10);

                //prepare carryOut for the next sum
                carryOut = partialSum / 10;
            }

            if (carryOut > 0)
            {
                result.Append(carryOut);
            }

            return result.ToString();
        }
    }
}
