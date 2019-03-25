using System;
using System.Linq;

namespace Solution1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "The quick brown fox jumps over the lazy dog";
            string cipherText = Encipher(text, 3);
            string plainText = Decipher(cipherText, 3);

            Console.WriteLine($"cipherText: {cipherText}");
            Console.WriteLine($"plainText: {plainText}");
        }

        static string Encipher(string str, int num)
        {
            var res = str.Select(c => 
            {
                if (!char.IsLetter(c)) return c;
                char offset = char.IsUpper(c) ? 'A' : 'a';
                return (char)((((c + num) - offset) % 26) + offset);
            });
            return string.Concat(res);
        }

        static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
    }
}
