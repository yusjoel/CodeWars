using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars.Kyu3
{
    /// <summary>
    ///     Binomial Expansion
    /// </summary>
    /// <remarks>https://www.codewars.com/kata/binomial-expansion/train/csharp</remarks>
    /// <remarks>https://www.intmath.com/series-binomial-theorem/4-binomial-theorem.php</remarks>
    public class BinomialExpansion
    {
        public static string Expand(string expr)
        {
            // (ax+b)^n
            string pattern = @"\((-?\d*)(\w)*([+-]\d*)\)\^(\d*)";
            if (!Regex.IsMatch(expr, pattern))
                throw new ArgumentException("not match pattern (ax+b)^n", nameof(expr));

            var match = Regex.Match(expr, pattern);

            // a is integer...trap
            long a;
            string s = match.Groups[1].ToString();
            if (string.IsNullOrEmpty(s))
            {
                // If a = 1, no coefficient will be placed in front of the variable
                a = 1;
            }
            else
            {
                // If a = -1, a "-" will be placed in front of the variable.
                if (s == "-")
                    a = -1;
                else
                    long.TryParse(s, out a);
            }

            // x is any one character long variable
            string x = match.Groups[2].ToString();

            // b is integer
            long b;
            long.TryParse(match.Groups[3].ToString(), out b);

            // n is a natural number
            int n;
            int.TryParse(match.Groups[4].ToString(), out n);
            if (n < 0)
                throw new ArgumentException("n < 0");

            Console.WriteLine($"({a}*{x}+{b})^{n}");

            if (n == 0) return "1";

            var stringBuilder = new StringBuilder();
            for (int i = 0; i <= n; i++)
            {
                // shit. ^ is XOR
                int exponent = n - i;
                long coefficient = Combine(n, i) * Power(a, exponent) * Power(b, i);
                if (coefficient > 0)
                {
                    if (stringBuilder.Length > 0)
                        stringBuilder.Append("+");

                    // If the power of the term is 0, only the coefficient should be included.
                    if (coefficient != 1 || exponent == 0)
                        stringBuilder.Append(coefficient);
                }
                else if (coefficient == 0)
                {
                    // If the coefficient of a term is zero, the term should not be included.
                    continue;
                }
                else
                {
                    // If the coefficient of a term is -1, only the "-" should be included.
                    // If the power of the term is 0, only the coefficient should be included.
                    if (coefficient == -1 && exponent > 0)
                        stringBuilder.Append("-");
                    else
                        stringBuilder.Append(coefficient);
                }

                if (exponent > 1)
                    stringBuilder.AppendFormat("{0}^{1}", x, exponent);
                else if (exponent == 1)
                    // If the power of the term is 1, the carrot and power should be excluded.
                    stringBuilder.AppendFormat(x);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     组合
        ///     <para>nCi = n!/r!/(n-r)! = n(n-1)...(n-r+1)/r!</para>
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static long Combine(int n, int r)
        {
            long c = 1;
            for (int i = 0; i < r; i++) c *= n - i;
            for (int i = 0; i < r; i++) c /= r - i;
            return c;
        }

        /// <summary>
        ///     幂
        ///     <para>a^n</para>
        /// </summary>
        /// <param name="a">base</param>
        /// <param name="n">index or power or exponent</param>
        /// <returns></returns>
        private static long Power(long a, int n)
        {
            long power = 1;
            for (int i = 0; i < n; i++) power *= a;
            return power;
        }
    }
}
