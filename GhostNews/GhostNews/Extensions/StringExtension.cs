using System;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.Extensions
{
    public static class StringExtension
    {
        public static bool ContainsAny(this string text, string characters)
        {
            foreach (char letter in text)
            {
                foreach(char character in characters)
                {
                    if (letter == character) return true;
                }
            }

            return false;
        }

        public static bool ContainsNumber(this string text)
        {
            foreach (char letter in text)
            {
                if (char.IsDigit(letter)) return true;
            }
            return false;
        }

        public static bool ContainsUpper(this string text)
        {
            foreach (char letter in text)
            {
                if (char.IsUpper(letter)) return true;
            }
            return false;
        }

        public static bool ContainsLower(this string text)
        {
            foreach (char letter in text)
            {
                if (char.IsLower(letter)) return true;
            }
            return false;
        }
    }
}
