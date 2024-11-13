using System;

namespace ExtensionMethodsAndGenericsDemo
{
    public static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int CountOccurrences(this string input, char character)
        {
            int count = 0;
            foreach (var c in input)
            {
                if (c == character) count++;
            }
            return count;
        }
    }
}
