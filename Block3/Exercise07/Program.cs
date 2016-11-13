using System;
using System.IO;
using System.Net;

namespace Exercise07
{
    public class Program
    {
        static void Main(string[] args)
        {
            string webUrl;
            string localPath;
            string fileName;
            string savingPath;

            while (true)
            {

                Console.WriteLine("Please enter a valid URL path:");
                webUrl = Console.ReadLine();

                Console.WriteLine("Please enter a valid folders path where you want to save the file:");
                localPath = Console.ReadLine();
                checkLocalPath(localPath);

                Console.WriteLine("Please enter a valid name for your file:");
                fileName = Console.ReadLine();

                savingPath = localPath + "\\" + fileName;
                try
                {
                    DownloadFile(webUrl, savingPath);
                }
                catch (WebException exc)
                {
                    Console.WriteLine(exc.Message);
                }

            }

        }

        public static void DownloadFile(string url, string path)
        {

            WebClient Client = new WebClient();
            Client.DownloadFile(url, path);

        }
        public static void checkLocalPath(string path)
        {
            try
            {
                Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (PathTooLongException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message);
            }

        }
    }
}



