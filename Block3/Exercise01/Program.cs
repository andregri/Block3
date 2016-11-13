using System;
using System.Collections.Generic;

namespace Exercise01
{
    public class Program
    {
        static void Main(string[] args)
        {
            int element;
            List<int> list = new List<int>();

            Console.WriteLine("Enter array elements separeted by \\n. 'q' to end.");
            Console.WriteLine("Invalid values will be ignored!");

            while (true)
            {
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out element))
                {
                    list.Add(element);
                }
                else if (input == "q")
                {
                    break;
                }
            }

            Console.WriteLine("Your array is: ");
            foreach (int e in list)
            {
                Console.Write(e + "\t");
            }
            Console.WriteLine();

            int position = FirstElementGreaterThanNeighbours(list.ToArray());
            Console.WriteLine("The position of the first element greater than its neighbour is: " + position);
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
