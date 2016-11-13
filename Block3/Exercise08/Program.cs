using System;


namespace Exercise08
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a text, please:");
            string text = Console.ReadLine();

            Console.WriteLine("Enter a chiper, please:");
            string chiper = Console.ReadLine();

            ushort[] encrypted = EncryptText(text, chiper);

            Console.WriteLine("Encrypted text is:");
            foreach (ushort c in encrypted)
            {
                Console.Write("\\u{0:x4}", c);
            }
            Console.WriteLine();
        }

        public static ushort[] EncryptText(string text, string chiper)
        {
            long length = text.Length;
            ushort[] encrypted = new ushort[length];

            for (int i = 0; i < length; i++)
            {
                ushort t = text[i];
                ushort c = chiper[i % chiper.Length];
                encrypted[i] = (ushort)(t ^ c);
            }

            return encrypted;
        }
    }
}
