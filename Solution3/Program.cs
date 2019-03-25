using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solution3
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
            return Regex.Replace(str, @"([A-Z])|([a-z])", m => 
            {
                int offset = 0;
                if (m.Groups[1].Success) offset = 65;
                if (m.Groups[2].Success) offset = 97;
                return ((char)((((m.Value[0] + num) - offset) % 26) + offset)).ToString();
            });
        }

        static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
    }
}
