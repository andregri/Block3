using System;


namespace Exercise01
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool GreaterThanNeighbours(int[] array, int index)
        {
            int length = array.Length;

            if (length == 1)
            {
                return true;
            }
            else if (length > 1)
            {
                if (index == 0 && array[0] > array[1])
                {
                    return true;
                }
                else if (index == array.Length - 1 && array[index - 1] < array[index])
                {
                    return true;
                }
                else if (array[index] > array[index - 1] && array[index] > array[index + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
