using System;
using System.IO;
using System.Net;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            string webUrl;
            string localPath;
            string fileName;
            string savingPath;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a valid URL path:");
                    webUrl = Console.ReadLine();
                    checkWebUrl(webUrl);
                    
                    Console.WriteLine("Please enter a valid folders path where you want to save the file:");
                    localPath = Console.ReadLine();
                    checkLocalPath(localPath);

                    Console.WriteLine("Please enter a valid name for your file:");
                    fileName = Console.ReadLine();

                    savingPath = localPath + "\\" + fileName;
                    
                    WebClient Client = new WebClient();
                    Client.DownloadFile(webUrl, savingPath);
                }
                catch (System.Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

        }

        public static void checkWebUrl(string url)
        {
            try
            {
                Uri myUri;
                Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out myUri);
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public static void checkLocalPath(string path)
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



