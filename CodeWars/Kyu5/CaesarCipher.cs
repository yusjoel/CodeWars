using System;
using System.Text;

namespace CodeWars.Kyu5
{
    /// <summary>
    ///     Rot13
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/rot13-1/train/csharp
    /// </remarks>
    public class CaesarCipher
    {
        // 这道无趣的题目不过真有不少解法
        // 1. 从表1获取index, 到表2获取结果
        // var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        // var code = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";
        // 2. 先选择Lower表和Upper表, 获取Index, 然后+13再除26取余
        //  LOWER = "abcdefghijklmnopqrstuvwxyz";
        //  UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // 3. 和'm', 'M'进行比较, 小于+13, 大于-13
        // 假设13这个值作为一个参数, 方法2改动最小, 并且支持任意的值


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
