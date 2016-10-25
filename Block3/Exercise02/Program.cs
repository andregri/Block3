using System;

namespace Exercise02
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int[] InitLargeNumber(long size = 10000)
        {
            //the least significant digits is at position 0
            int[] largeNumber = new int[size];
            Random random = new Random();

            for (long i = 0; i < size - 1; i++)
            {
                largeNumber[i] = random.Next(0, 10);
            }

            //last digit (most significant) must be different from zeros
            largeNumber[size - 1] = random.Next(1, 10);

            return largeNumber;
        }

        public static int SumDigits(int[] firstNumber, int[] secondNumber, long index)
        {
            int sum = 0;

            if (index == 0)
            {
                sum = (firstNumber[0] + secondNumber[0]) % 10;
            }
            else
            {
                sum = (firstNumber[index] + secondNumber[index]) % 10 + (firstNumber[index - 1] + secondNumber[index - 1]) / 10;
                //truncate digit if it's greater or equal than 10 
                if (sum >= 10)
                {
                    sum %= 10;
                }
            }

            return sum;
        }

        public static int[] SumLargeNumbers(int[] firstNumber, int[] secondNumber)
        {
            int length = firstNumber.Length;
            int[] sum = new int[length];

            for (int i = 1; i < length; i++)
            {
                sum[i] = SumDigits(firstNumber, secondNumber, i);
            }

            return sum;
        }
    }
}
