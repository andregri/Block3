using System;
using System.Text;

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

        private static Random random = new Random();

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
            string laudatoryPhrase = laudatoryPhrases[random.Next(0, laudatoryPhrases.Length)];
            string laudatoryStory = laudatoryStories[random.Next(0, laudatoryStories.Length)];
            string authorName = authorsNames[random.Next(0, authorsNames.Length)];
            string authorLastName = authorsLastNames[random.Next(0, authorsLastNames.Length)];
            string city = cities[random.Next(0, cities.Length)];

            StringBuilder message = new StringBuilder();
            message.Append(laudatoryPhrase).Append(" ").Append(laudatoryStory).Append(" -- ")
                .Append(authorName).Append(" ").Append(authorLastName).Append(", ").Append(city);

            return message.ToString();
        }
    }
}
