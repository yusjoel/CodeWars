using System;
using System.Text;

namespace CodeWars.Kyu5
{
    /// <summary>
    ///     Rot13
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/530e15517bc88ac656000716/train/csharp
    /// </remarks>
    public class CaesarCipher
    {
        public static string Rot13(string message)
        {
            if(message == null)
                throw new ArgumentNullException(nameof(message));

            var stringBuilder = new StringBuilder();
            foreach (char c in message)
                if (char.IsLetter(c))
                {
                    bool isLower = char.IsLower(c);
                    char a = isLower ? 'a' : 'A';
                    char z = isLower ? 'z' : 'Z';
                    char ch = (char) (c + 13);
                    if (ch > z)
                        ch = (char) (a + ch - z - 1);

                    stringBuilder.Append(ch);
                }
                else
                {
                    stringBuilder.Append(c);
                }
            return stringBuilder.ToString();
        }
    }
}
