using System.Text;

namespace CodeWars
{
    /// <summary>
    ///     Simple Encryption #1 - Alternating Split
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/57814d79a56c88e3e0000786/train/csharp
    /// </remarks>
    public class SimpleEncryption
    {
        /// <summary>
        /// My Solution
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Encrypt(string text, int n)
        {
            if (text == null)
                return null;

            if (n <= 0)
                return text;

            string encryptedText = text;
            var stringBuilder = new StringBuilder();
            int textLength = text.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < textLength / 2; j++)
                    stringBuilder.Append(encryptedText[j * 2 + 1]);

                for (int j = 0; j < (textLength + 1) / 2; j++)
                    stringBuilder.Append(encryptedText[j * 2]);
                encryptedText = stringBuilder.ToString();
                stringBuilder.Length = 0;
            }
            return encryptedText;
        }

        /// <summary>
        /// My Solution
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedText, int n)
        {
            if (encryptedText == null)
                return null;

            if (n <= 0)
                return encryptedText;

            string text = encryptedText;
            var stringBuilder = new StringBuilder();
            int textLength = text.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < textLength; j++)
                {
                    int index = (j % 2 == 0 ? textLength / 2 : 0) + j / 2;
                    stringBuilder.Append(text[index]);
                }
                text = stringBuilder.ToString();
                stringBuilder.Length = 0;
            }
            return text;
        }


        public static string Encrypt2(string text, int n)
        {
            if (n <= 0 || text == null)
                return text;

            string result = "";

            // 这里确实写的更易读
            for (int i = 1; i < text.Length; i += 2) result += text[i];
            for (int i = 0; i < text.Length; i += 2) result += text[i];

            return Encrypt2(result, n - 1);
        }
    }
}