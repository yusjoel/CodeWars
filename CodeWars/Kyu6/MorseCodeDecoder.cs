using System;
using System.Text;

namespace CodeWars.Kyu6
{
    /// <summary>
    ///     Decode the Morse code (Morse 1/3)
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/decode-the-morse-code/train/csharp
    /// </remarks>
    public class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            var decode = new StringBuilder();
            var code = new StringBuilder();
            int spaceCount = 0;
            bool openParentheses = false;
            foreach (char c in morseCode)
                switch (c)
                {
                    case '.':
                    case '-':
                        if (spaceCount == 3)
                            decode.Append(' ');
                        code.Append(c);
                        spaceCount = 0;
                        break;
                    case ' ':
                        if (spaceCount == 0)
                        {
                            if (code.Length > 0)
                            {
                                string key = code.ToString();
                                if (key == "-.--.-")
                                {
                                    decode.Append(openParentheses ? ')' : '(');
                                    openParentheses = !openParentheses;
                                }
                                else
                                {
                                    decode.Append(MorseCode.Get(key));
                                }
                                code.Length = 0;
                                spaceCount = 1;
                            }
                        }
                        else
                        {
                            spaceCount++;
                        }
                        break;
                    default:
                        throw new ArgumentException(nameof(morseCode));
                }

            if (code.Length > 0)
                decode.Append(MorseCode.Get(code.ToString()));

            return decode.ToString();
        }
    }
}
