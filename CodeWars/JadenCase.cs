using System;
using System.Text;

namespace CodeWars
{
    public static class JadenCase
    {
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
    }
}
