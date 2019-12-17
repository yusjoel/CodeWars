using System;
using System.Collections.Generic;

namespace CodeWars.Kyu5
{
    /// <summary>
    ///     Best travel
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/best-travel/train/csharp
    /// </remarks>
    public class SumOfK
    {
        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// </summary>
        /// <param name="t">maximum sum of distances, integer >= 0</param>
        /// <param name="k">number of towns to visit, k >= 1</param>
        /// <param name="ls">list of distances, all distances are positive or null integers and this list has at least one element</param>
        /// <returns>
        ///     the "best" sum ie the biggest possible sum of k distances less than or equal to the given limit t, if that sum
        ///     exists, or otherwise null
        /// </returns>
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            if (t < 0)
                throw new ArgumentOutOfRangeException(nameof(t));

            if (k < 1)
                throw new ArgumentOutOfRangeException(nameof(k));

            if (ls == null)
                throw new ArgumentNullException(nameof(ls));

            if (ls.Count == 0)
                throw new ArgumentException("ls is empty");

            return ChooseBestSum(t, k, ls, 0);
        }

        private static int? ChooseBestSum(int t, int k, List<int> ls, int position)
        {
            // 超过最大值, 失败
            if (t < 0)
                return null;

            // 达到次数, 结束
            if (k == 0)
                return 0;

            // 候选不够, 失败
            if (ls.Count - position < k)
                return null;

            // 依次选取列表中的值
            int i = ls[position];
            // 使用的情况
            var max1 = ChooseBestSum(t - i, k - 1, ls, position + 1);
            // 不用的情况
            var max2 = ChooseBestSum(t, k, ls, position + 1);

            // 选取最大值
            if (max1 == null)
                return max2;

            max1 += i;
            if (max2 == null)
                return max1;

            return max2 > max1 ? max2 : max1;
        }
    }
}
