using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise09
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath;
            string savepath;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a valid folders path where you want to read input file:");
                    filePath = Console.ReadLine();
                    checkSavePath(filePath);

                    Console.WriteLine("Please enter a valid folders path where you want to save the file:");
                    savepath = Console.ReadLine();
                    checkSavePath(savepath);

                    ExtractEmails(filePath, savepath);
                }

                catch (System.Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

            }
        }

        public static void ExtractEmails(string inFilePath, string outFilePath)
        {
            //read File 
            string data = File.ReadAllText(inFilePath);
            string pattern = (@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            //instantiate with this pattern 
            Regex emailRegex = new Regex(pattern, RegexOptions.IgnoreCase);

            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(data);

            StringBuilder sb = new StringBuilder();

            foreach (Match emailMatch in emailMatches)
            {
                sb.AppendLine(emailMatch.Value);
            }

            //store to file
            File.WriteAllText(outFilePath, sb.ToString());
        }

        public static void checkSavePath(string path)
        {
            try
            {
                Directory.Exists(path);
            }

            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
