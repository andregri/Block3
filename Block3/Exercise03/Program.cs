using System;
using System.IO;
using System.Collections.Generic;

namespace Exercise03
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter a valid path:");
                string path = Console.ReadLine();
                Console.WriteLine("\n");

                Directory.Exists(path);
                foreach (string element in TraverseFolder(path))
                {
                    Console.WriteLine(element);
                }
            }
        }

        public static string[] TraverseFolder(string dir)
        {
            List<string> elements = new List<string>();

            try
            {
                // for each folder get all files in
                foreach (string file in Directory.GetFiles(dir))
                    elements.Add(file);

                // slide the entire path and get all folders 
                foreach (string directory in Directory.GetDirectories(dir))
                {
                    elements.Add(directory + "\\");
                    elements.AddRange(TraverseFolder(directory));
                }
            }
            // using catch to manage read permission denied 
            catch (UnauthorizedAccessException exc)
            {
                Console.WriteLine(exc.Message);
            }

            return elements.ToArray();
        }
    }
}