using System;
using System.Text.RegularExpressions;

namespace CodeWars
{
    /// <summary>
    ///     Dubstep
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/dubstep/train/csharp
    /// </remarks>
    public class Dubstep
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SongDecoder(string input)
        {
            var substrings = input.Split(new[] { "WUB" }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", substrings);
        }

        public static string SongDecoder2(string input)
        {
            return Regex.Replace(input, "(WUB)+", " ").Trim();
        }
    }
}
