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
                if (index == 0)
                {
                    if (array[0] > array[1])
                    {
                        return true;
                    }
                }
                else if (index == length - 1)
                {
                    if (array[index - 1] < array[index])
                    {
                        return true;
                    }
                }
                else if (array[index] > array[index - 1] && array[index] > array[index + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public static int FirstElementGreaterThanNeighbours(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool isGreater = GreaterThanNeighbours(array, i);

                if (isGreater)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
