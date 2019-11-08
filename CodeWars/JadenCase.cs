using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CodeWars
{
    /// <summary>
    ///     Jaden Casing Strings
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/5390bac347d09b7da40006f6
    /// </remarks>
    public static class JadenCase
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToJadenCase(this string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
                return string.Empty;

            var substrings = phrase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stringBuilder = new StringBuilder();
            int length = substrings.Length;
            for (int i = 0; i < length; i++)
            {
                string substring = substrings[i];
                stringBuilder.Append(char.ToUpper(substring[0])).Append(substring.Substring(1));

                if (i < length - 1)
                    stringBuilder.Append(" ");
            }
            return stringBuilder.ToString();
        }

        public static string ToJadenCase2(this string phrase)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
        }

        public static string ToJadenCase3(this string phrase)
        {
            return string.Join(" ", phrase.Split().Select(i => char.ToUpper(i[0]) + i.Substring(1)));
        }
    }
}
