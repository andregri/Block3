using System;
using System.IO;
using System.Net;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            string webpath;
            string savepath;
            string filename;
            string allPath;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a valid URL path:");
                    webpath = Console.ReadLine();
                    checkWebPath(webpath);

                    Console.WriteLine("Please enter a valid folders path where you want to save the file:");
                    savepath = Console.ReadLine();
                    checkSavePath(savepath);

                    Console.WriteLine("Please enter a valid name for your file:");
                    filename = Console.ReadLine();

                    allPath = (@"" + savepath + filename);


                    WebClient Client = new WebClient();
                    Client.DownloadFile(webpath, allPath);
                }

                catch (System.Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

        }

        public static void checkWebPath(string path)
        {
            try
            {
                Uri myUri;
                Uri.TryCreate(path, UriKind.RelativeOrAbsolute, out myUri);
            }

            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
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



