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
            int lineNumber = 1;

            try
            {
                using (reader = new StreamReader(file))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        int.Parse(line);
                        lineNumber++;
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
