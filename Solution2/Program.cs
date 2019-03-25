using System;
using System.Text.RegularExpressions;

namespace Solution2
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
            string res = "";
            foreach (char c in str)
            {
                Match m = Regex.Match(c.ToString(), @"([A-Z])|([a-z])");
                if (m.Success)
                {
                    int offset = 0;
                    if (m.Groups[1].Success) offset = 65;
                    if (m.Groups[2].Success) offset = 97;
                    res += (char)((((c + num) - offset) % 26) + offset);
                }
                else
                {
                    res += c;
                }
            }
            return res;
        }

        static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
    }
}
