using System;

namespace Exercise02
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int[] GetRandomLargeNumber(long size = 10000)
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

        public static int GetCarry(int[] firstNumber, int[] secondNumber, long index)
        {
            if (index > 0)
            {
                return (firstNumber[index] + secondNumber[index]) / 10;
            }

            return 0;
        }

        public static int SumDigits(int[] firstNumber, int[] secondNumber, long index)
        {
            int sum = 0;

            //sum digits
            sum = (firstNumber[index] + secondNumber[index]) % 10;
            
            //add carry
            sum += Program.GetCarry(firstNumber, secondNumber, index - 1);

            return sum;
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

            for (int i = 1; i < length; i++)
            {
                sum[i] = SumDigits(firstNumber, secondNumber, i);
            }

            return sum;
        }
    }
}
