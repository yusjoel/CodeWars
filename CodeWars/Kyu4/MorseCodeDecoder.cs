using CodeWars.Kyu6;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars.Kyu4
{
    /// <summary>
    ///     Decode the Morse code, advanced (2/3 Morse code)
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/decode-the-morse-code-advanced/train/csharp
    /// </remarks>
    public class MorseCodeDecoder
    {
        private static void ParsePause(StringBuilder morseCode, int unconnectedTimes, int timeUnit)
        {
            if (unconnectedTimes == timeUnit)
            {
                // pause between dots and dashes
            }
            else if (unconnectedTimes == timeUnit * 3)
            {
                // pause between characters
                morseCode.Append(' ');
            }
            else if (unconnectedTimes == timeUnit * 7)
            {
                // pause between words
                morseCode.Append("   ");
            }
            else if (unconnectedTimes > 0)
            {
                throw new ArgumentException($"unconnectedTimes = {unconnectedTimes}", nameof(unconnectedTimes));
            }
        }

        private static void ParseDotAndDash(StringBuilder morseCode, int connectedTimes, int timeUnit)
        {
            if (connectedTimes == timeUnit)
                morseCode.Append('.');
            else if (connectedTimes == timeUnit * 3)
                morseCode.Append('-');
            else if (connectedTimes > 0)
                // if you have trouble discerning if the particular sequence of 1's is a dot or a dash, assume it's a dot.
                morseCode.Append('.');
        }

        /// <summary>
        ///     如果n个时间单位是m的倍数, 那么对n/m计数加1
        /// </summary>
        /// <param name="map"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        private static void Count(Dictionary<int, int> map, int n, int m)
        {
            if (n % m == 0)
            {
                int i = n / m;
                if (map.ContainsKey(i))
                    map[i]++;
                else
                    map[i] = 1;
            }
        }

        /// <summary>
        ///     寻找传输率
        ///     读取一段连续的1, 假设它是dot, 进行计数, 如果它能被3整除, 也把它当成dash计数
        ///     读取一段连续的0, 同样有1个时间单位,3个时间单位, 7个时间单位的可能
        ///     最后将计数最大的值当成1个时间单位
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        private static int FindOutTransmissionRate(string bits)
        {
            var map = new Dictionary<int, int>();
            int n = 0;
            int m = 0;
            bool leadZero = true;
            foreach (char bit in bits)
                if (bit == '0')
                {
                    if (n > 0)
                    {
                        Count(map, n, 1);
                        Count(map, n, 3);
                    }

                    n = 0;
                    m++;
                }
                else if (bit == '1')
                {
                    if (m > 0 && !leadZero)
                    {
                        Count(map, m, 1);
                        Count(map, m, 3);
                        Count(map, m, 7);
                    }

                    leadZero = false;
                    m = 0;
                    n++;
                }

            int max = 0;
            int rate = 0;
            foreach (var pair in map)
                if (pair.Value > max)
                {
                    max = pair.Value;
                    rate = pair.Key;
                }
            return rate;
        }

        public static string DecodeBits(string bits)
        {
            var morseCode = new StringBuilder();
            try
            {
                int timeUnit = FindOutTransmissionRate(bits);
                Console.WriteLine($"timeUnit = {timeUnit}");

                int connectedTimes = 0;
                int unconnectedTimes = 0;
                foreach (char bit in bits)
                    switch (bit)
                    {
                        case '1':
                            if (morseCode.Length > 0)
                                ParsePause(morseCode, unconnectedTimes, timeUnit);
                            unconnectedTimes = 0;
                            connectedTimes++;
                            break;
                        case '0':
                            ParseDotAndDash(morseCode, connectedTimes, timeUnit);
                            unconnectedTimes++;
                            connectedTimes = 0;
                            break;
                        default:
                            throw new ArgumentException(nameof(bits));
                    }
                ParseDotAndDash(morseCode, connectedTimes, timeUnit);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"bits = {bits}", nameof(bits), e);
            }

            return morseCode.ToString();
        }

        public static string DecodeMorse(string morseCode)
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
