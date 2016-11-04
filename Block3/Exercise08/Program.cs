using System;


namespace Exercise08
{
    public class Program
    {
        static void Main(string[] args)
        {
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
