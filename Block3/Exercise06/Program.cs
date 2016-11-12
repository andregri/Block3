using System;
using System.IO;
using System.Collections.Generic;

namespace Exercise06
{
    public class Program
    {
        static void Main(string[] args)
        {
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
