using System;


namespace Exercise08
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static char[] EncryptText(char[] text, char[] chiper)
        {
            long length = text.Length;
            char[] encrypted = new char[length];

            for (int i = 0; i < length; i++)
            {
                ushort t = text[i];
                ushort c = chiper[i % chiper.Length];
                encrypted[i] = (char)(t ^ c);
            }

            return encrypted;
        }
    }
}
