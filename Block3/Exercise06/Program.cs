using System;
using System.IO;
using System.Collections.Generic;

namespace Exercise06
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] files = { @"..\..\correct.txt", @"..\..\wrong.txt" };

            foreach (string f in files)
            {
                Console.WriteLine("Parsing {0}:", f);
                try
                {
                    int[] numbers = ParseFile(f);
                    foreach (int n in numbers)
                    {
                        Console.Write("{0,3}", n);
                    }
                }
                catch (FileParseException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("\n");
            }
        }

        public static int[] ParseFile(string file)
        {
            StreamReader reader = null;
            List<int> numbers = new List<int>();
            int lineNumber = 1;

            try
            {
                using (reader = new StreamReader(file))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        int n = int.Parse(line);
                        numbers.Add(n);
                        lineNumber++;
                    }
                }
            }
            catch (FormatException e)
            {
                throw new FileParseException(file, lineNumber, e);
            }

            return numbers.ToArray();
        }
    }
}
