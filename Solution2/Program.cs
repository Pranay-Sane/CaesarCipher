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
            int i = 0;
            var matches = Regex.Matches(str, @"([A-Z])|([a-z])");
            foreach(Match m in matches)
            {
                char letter = m.Value[0];
                while(letter != str[i])
                {                    
                    res += str[i];
                    i++;
                }
                int offset = 0;
                if (m.Groups[1].Success) offset = 65;
                if (m.Groups[2].Success) offset = 97;
                res += (char)((((letter + num) - offset) % 26) + offset);
                i++;
            }
            return res;
        }

        static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
    }
}
