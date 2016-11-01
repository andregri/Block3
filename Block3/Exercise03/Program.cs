using System;
using System.IO;

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

                //string example =(@"/home/jarvis/Documenti/University");
                try
                {
                    Directory.Exists(path);
                    DirectorySearch(path);
                }
                catch (System.Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        static void DirectorySearch(string dir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dir))
                    Console.WriteLine(file);

                foreach (string directory in Directory.GetDirectories(dir))
                {
                    //Console.BackgroundColor = ConsoleColor.DarkCyan;
                    //Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(directory);
                    //Console.ResetColor();
                    DirectorySearch(directory);
                }
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}