using System;
using System.IO;

namespace Exercise06
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static void ParseFile(string file)
        {
            StreamReader reader = null;
            int lineNumber = 0;

            try
            {
                using (reader = new StreamReader(file))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        int.Parse(line);
                    }
                }
            }
            catch (FormatException e)
            {
                throw new FileParseException(file, lineNumber, e);
            }
        }
    }
}
