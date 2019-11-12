// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

using System.Collections.Generic;
using System.Text;

namespace CodeWars.Kyu6
{
    /// <summary>
    ///     Numericals of a String
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/numericals-of-a-string/train/csharp
    /// </remarks>
    public class JomoPipi
    {
        public static string Numericals(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            var map = new Dictionary<char, int>();
            var stringBuilder = new StringBuilder();

            foreach (char c in s)
            {
                if (map.TryGetValue(c, out int count))
                    count++;
                else
                    count = 1;
                stringBuilder.Append(count);
                map[c] = count;
            }

            return stringBuilder.ToString();
        }
    }
}
