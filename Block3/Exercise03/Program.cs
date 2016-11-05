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
                try
                {
                    Directory.Exists(path);
                    foreach (string element in DirectorySearch(path))
                    {
                        Console.WriteLine(element);
                    }
                }
                catch (System.Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        static string[] DirectorySearch(string dir)
        {
            List<string> elements = new List<string>();
            
            try
            {
                //  for each folder get all files in
                foreach (string file in Directory.GetFiles(dir))
                    elements.Add(file + "\n");

                // slide the entire path and get all folders 
                foreach (string directory in Directory.GetDirectories(dir))
                {
                    Console.WriteLine(directory);
                    DirectorySearch(directory);

                    elements.Add(directory + "\n");
                }  
            }
            // using catch to manage read permission denied 
            catch (System.UnauthorizedAccessException exc)
            {
                Console.WriteLine(exc.Message);
            }

            return elements.ToArray();
        }
    }
}