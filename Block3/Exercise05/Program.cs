using System;


namespace Exercise05
{
    public class Program
    {
        private static string[] laudatoryPhrases = {"The product is excellent.", "This is a great product.", "I use this productconstantly.",
                                                    "This is the best product from this category." };
        private static string[] laudatoryStories = { "Now I feel better.", "I managed to change.", "It made some miracle.",
                                                    "I can’t believe it, but now I am feeling great.", "You should try it, too. I am very satisfied."};
        private static string[] authorNames = { "Dayan", "Stella", "Hellen", "Kate" };
        private static string[] authroLastNames = { "Johnson", "Peterson", "Charles" };
        private static string[] cities = { "London", "Paris", "Berlin", "New York", "Madrid" };

        private static string laudatoryPhrase;
        private static string laudatoryStory;
        private static string authorName;
        private static string authroLastName;
        private static string city;
        private static string Message;

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

        private static string GenerateRandomAdvertisingMessage()
        {
            laudatoryPhrase = laudatoryPhrases[new Random().Next(0, laudatoryPhrases.Length)];
            laudatoryStory = laudatoryStories[new Random().Next(0, laudatoryStories.Length)];
            authorName = authorNames[new Random().Next(0, authorNames.Length)];
            authroLastName = authroLastNames[new Random().Next(0, authroLastNames.Length)];
            city = cities[new Random().Next(0, cities.Length)];
            Message = laudatoryPhrase + " " + laudatoryStory + " -- " + authorName + " " + authroLastName + " " + city;

            return Message;
        }
    }
}
