using System;
using System.Collections.Generic;

namespace CodeWars.Kyu4
{
    /// <summary>
    ///     Sum of Intervals
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/sum-of-intervals/train/csharp
    /// </remarks>
    public class Intervals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            // 本题还有一个解法是按照Item1排序, 然后每次计算(Max(F, n.Item1), n.Item2)
            // F是前n-1项中最大的Item2, 但实际是把复杂度放到排序去了
            // 下面的代码优化后应该也能达到O(nLgn)

            var list = new List<(int, int)>();
            int sum = 0;
            foreach (var interval in intervals)
            {
                bool joined;
                var b = interval;
                do
                {
                    joined = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        var a = list[i];
                        if (a.Item1 > b.Item2 || a.Item2 < b.Item1)
                            continue;

                        list.RemoveAt(i);
                        b = (Math.Min(a.Item1, b.Item1), Math.Max(a.Item2, b.Item2));

                        joined = true;
                        sum -= a.Item2 - a.Item1;
                        break;
                    }
                } while (joined);

                list.Add(b);
                sum += b.Item2 - b.Item1;
            }

            return sum;
        }
    }
}
