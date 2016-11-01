using System;

namespace Exercise02
{
    public class Program
    {
        public static Random random = new Random();

        static void Main(string[] args)
        {
            long size1 = random.Next(10000, 100000);
            int[] num1 = GetRandomLargeNumber(size1);

            long size2 = random.Next(10000, 100000);
            int[] num2 = GetRandomLargeNumber(size2);

            //print first number
            Console.Write("...");
            for(int i = 19; i >= 0; i--)
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
            int[] sum = SumLargeNumbers(num1, num2);
            Console.Write("...");
            for (int i = 19; i >= 0; i--)
            {
                Console.Write("{0,2}", sum[i]);
            }
            Console.WriteLine("\n");
        }

        public static int[] GetRandomLargeNumber(long size = 10000)
        {
            //the least significant digits is at position 0
            int[] largeNumber = new int[size];

            for (long i = 0; i < size - 1; i++)
            {
                largeNumber[i] = random.Next(0, 10);
            }

            //last digit (most significant) must be different from zeros
            largeNumber[size - 1] = random.Next(1, 10);

            return largeNumber;
        }

        public static int GetCarry(int[] firstNumber, int[] secondNumber, long index)
        {
            int carry = 0;

            if (index >= 0)
            {
                int sum = firstNumber[index] + secondNumber[index];

                if (sum == 9 && index != 0)
                {
                    carry = (sum + GetCarry(firstNumber, secondNumber, index - 1)) / 10;
                }
                else
                {
                    carry = sum / 10;
                }
            }

            return carry;
        }

        public static int SumDigits(int[] firstNumber, int[] secondNumber, long index)
        {
            int sum = 0;

            //sum digits
            sum = firstNumber[index] + secondNumber[index];

            //get carry
            int carry = Program.GetCarry(firstNumber, secondNumber, index - 1);

            return (sum + carry) % 10;
        }

        public static int[] ExtendLargeNumber(int[] largeNumber, int newSize)
        {
            int oldSize = largeNumber.Length;

            if (oldSize < newSize)
            {
                //extend size of largeNumber adding leading zeroes
                int[] newNumber = new int[newSize];

                for (int i = 0; i < oldSize; i++)
                {
                    newNumber[i] = largeNumber[i];
                }

                return newNumber;
            }

            return largeNumber;
        }

        public static int[] SumLargeNumbers(int[] firstNumber, int[] secondNumber)
        {
            int length = Math.Max(firstNumber.Length, secondNumber.Length);

            firstNumber = Program.ExtendLargeNumber(firstNumber, length);
            secondNumber = Program.ExtendLargeNumber(secondNumber, length);

            int[] sum = new int[length];

            for (int i = 0; i < length; i++)
            {
                sum[i] = SumDigits(firstNumber, secondNumber, i);
            }

            return sum;
        }
    }
}
