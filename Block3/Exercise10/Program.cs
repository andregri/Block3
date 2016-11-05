using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise10
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            do
            {
                Console.Write("Enter a string (press 'q' to exit):  ");
                userInput = Console.ReadLine();
                CountingLetters(userInput);

            } while (userInput != "q");

        }
        public static void CountingLetters(string input)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            for (int index = 0; index < input.Length; index++)
            {
                char key = input[index];

                if (!dict.ContainsKey(key))
                    dict.Add(key, 1);
                else
                    dict[input[index]]++;
            }

            foreach (var key in dict.OrderByDescending(value => value.Value).Take(315))
            {
                Console.WriteLine("{0}\t{1}", key.Key, key.Value);

            }
        }
    }
}
