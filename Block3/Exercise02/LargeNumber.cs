using System;
using System.Text;

namespace Exercise02
{
    //the least significant digit is at index 0.
    //maximum size is 10000
    public class LargeNumber
    {
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            int size1 = rand.Next(30, 10000);
            string num1 = Random(size1);

            int size2 = rand.Next(30, 10000);
            string num2 = Random(size2);

            //print first number
            Console.Write("...");
            for (int i = 19; i >= 0; i--)
            {
                Console.Write("{0,2}", num1[i]);
            }
            Console.WriteLine(" +");

            //print second number
            Console.Write("...");
            for (int i = 19; i >= 0; i--)
            {
                Console.Write("{0,2}", num2[i]);
            }
            Console.WriteLine(" =");

            //print a line
            for (int i = 0; i < 46; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            //print sum
            string sum = Sum(num1, num2);
            Console.Write("...");
            for (int i = 19; i >= 0; i--)
            {
                Console.Write("{0,2}", sum[i]);
            }
            Console.WriteLine("\n");
        }

        public static string Random(int size)
        {
            StringBuilder num = new StringBuilder(size);

            for (int i = 0; i < size - 1; i++)
            {
                num.Append(rand.Next(0, 10));
            }

            num.Append(rand.Next(1, 10));

            return num.ToString();
        }

        // if 'num' is smaller than 'newSize', add a padding of zeroes to 'num';
        // else return 'num' unmodified.
        public static string Extend(string num, int newSize)
        {
            StringBuilder newNum;
            int oldSize = num.Length;

            if (oldSize >= newSize)
            {
                return num;
            }
            else
            {
                newNum = new StringBuilder(num);

                for (int i = oldSize; i < newSize; i++)
                {
                    newNum.Append('0');
                }
            }

            return newNum.ToString();
        }

        public static string Sum(string a, string b)
        {
            int sizeMax = Math.Max(a.Length, b.Length);
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
