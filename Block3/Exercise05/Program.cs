using System;


namespace Exercise05
{
    public class Program
    {
        public static string[] laudatoryPhrases = {"The product is excellent.", "This is a great product.", "I use this product constantly.",
                                                    "This is the best product from this category." };
        public static string[] laudatoryStories = { "Now I feel better.", "I managed to change.", "It made some miracle.",
                                                    "I can’t believe it, but now I am feeling great.", "You should try it, too. I am very satisfied."};
        public static string[] authorsNames = { "Dayan", "Stella", "Hellen", "Kate" };
        public static string[] authorsLastNames = { "Johnson", "Peterson", "Charles" };
        public static string[] cities = { "London", "Paris", "Berlin", "New York", "Madrid" };

        static string laudatoryPhrase;
        static string laudatoryStory;
        static string authorName;
        static string authroLastName;
        static string city;
        static string Message;

        static void Main(string[] args)
        {
            string command = null;

            Console.WriteLine("Press 'q' to exit, otherwise each ENTER generates new random message\n\n");

            while (command != "q")
            {
                Console.WriteLine(GenerateRandomAdvertisingMessage());
                command = Console.ReadLine();
            }
        }

        public static string GenerateRandomAdvertisingMessage()
        {
            laudatoryPhrase = laudatoryPhrases[new Random().Next(0, laudatoryPhrases.Length)];
            laudatoryStory = laudatoryStories[new Random().Next(0, laudatoryStories.Length)];
            authorName = authorsNames[new Random().Next(0, authorsNames.Length)];
            authroLastName = authorsLastNames[new Random().Next(0, authorsLastNames.Length)];
            city = cities[new Random().Next(0, cities.Length)];
            Message = laudatoryPhrase + " " + laudatoryStory + " -- " + authorName + " " + authroLastName + " " + city;

            return Message;
        }
    }
}
