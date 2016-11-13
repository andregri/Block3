using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;

            while (true)
            {

                Console.WriteLine("Please enter a valid path:");
                path = Console.ReadLine();
                Console.WriteLine("\n");

                //string pathExample =(@"/home/jarvis/Documenti/University");

                Directory.Exists(path);
                foreach (string element in TraverseFolder(path))
                {
                    if (element.EndsWith("\\"))
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine(element);
                }

            }
        }

        static string[] TraverseFolder(string dir)
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