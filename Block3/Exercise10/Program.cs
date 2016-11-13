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
                var dictionary = CountingWords(userInput);

                foreach (var word in dictionary.OrderBy(value => value.Key))
                {
                    Console.WriteLine("{0,-20}{1}", word.Key, word.Value);
                }

            } while (userInput != "q");

        }
        public static SortedDictionary<string, int> CountingWords(string input)
        {
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();

            string[] stringSeparators = new string[] { " ", ",", ".", ";", ":", "\n" };
            string[] key = input.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in key)
            {
                if (!dict.ContainsKey(element))
                    dict.Add(element, 1);
                else
                    dict[element]++;
            }
            return dict;
        }
    }
}
