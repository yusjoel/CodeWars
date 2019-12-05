using System.Collections.Generic;
using System.Text;

namespace CodeWars.Kyu4
{
    /// <summary>
    ///     All Balanced Parentheses
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/all-balanced-parentheses/train/csharp
    /// </remarks>
    public class Balanced
    {
        private static readonly Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();

        private static readonly StringBuilder stringBuilder = new StringBuilder();

        /// <summary>
        ///     我的解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<string> BalancedParens(int n)
        {
            if (map.TryGetValue(n, out var result))
                return result;

            result = new List<string>();
            if (n == 0)
            {
                result.Add("");
                map[0] = result;
                return result;
            }

            if (n == 1)
            {
                result.Add("()");
                map[1] = result;
                return result;
            }

            // 用f(n)代表一种组合, 这个组合的定义如下
            // f(1) = {"()"}
            // f(2) = {(f(1)), f(1) + f(1)}
            // f(3) = {(f(2)), (f(1)) + f(1), f(1) + f(2)}
            // f(4) = {(f(3)), (f(2)) + f(1), (f(1)) + f(2), f(1) + f(3)}

            for (int i = 0; i < n; i++)
            {
                int m = n - i - 1;
                var r1 = BalancedParens(m);
                var r2 = BalancedParens(i);
                foreach (string s1 in r1)
                foreach (string s2 in r2)
                    result.Add($"({s1}){s2}");
            }

            map[n] = result;
            return result;
        }

        /// <summary>
        ///     另一种解, 比较难想到
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <param name="nOpen"></param>
        /// <param name="nClosed"></param>
        /// <param name="res"></param>
        public static void RecursiveParens(string s, int n, int nOpen, int nClosed, List<string> res)
        {
            if (nOpen < n)
                RecursiveParens(s + "(", n, nOpen + 1, nClosed, res);
            if (nClosed < nOpen)
                RecursiveParens(s + ")", n, nOpen, nClosed + 1, res);
            if (nOpen == n && nClosed == n)
                res.Add(s);
        }

        /// <summary>
        ///     修改了一下, 节约内存开销
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="n"></param>
        /// <param name="open"></param>
        /// <param name="close"></param>
        /// <param name="result"></param>
        public static void Solve(StringBuilder stringBuilder, int n, int open, int close, List<string> result)
        {
            if (open < n)
            {
                stringBuilder.Append('(');
                Solve(stringBuilder, n, open + 1, close, result);
                stringBuilder.Length -= 1;
            }

            if (close < open)
            {
                stringBuilder.Append(')');
                Solve(stringBuilder, n, open, close + 1, result);
                stringBuilder.Length -= 1;
            }

            if (open == n && close == n)
                result.Add(stringBuilder.ToString());
        }
    }
}
