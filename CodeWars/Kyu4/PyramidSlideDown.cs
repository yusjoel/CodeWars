using System;
using System.Linq;

namespace CodeWars.Kyu4
{
    /// <summary>
    ///     Pyramid Slide Down
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/551f23362ff852e2ab000037/train/csharp
    /// </remarks>
    public class PyramidSlideDown
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            if (pyramid == null)
                throw new ArgumentNullException(nameof(pyramid));

            int n = pyramid.Length;
            for (int i = 0; i < n; i++)
            {
                if (pyramid[i] == null)
                    throw new ArgumentException($"pyramid[{i}] is null");

                if (pyramid[i].Length != i + 1)
                    throw new ArgumentException($"pyramid[{i}].Length is no {i + 1}");
            }

            // 每个点都有两种可能, 上方的左路或者右路下来
            // 只要取两者之中的最大值即可
            // 考虑到不希望改动原始数据, 所以创建两个数组来记录
            // previous记录上一层各个节点的最大值, 为了不要判断出界的情况, 大小为n+1
            // 其中[0]和[n]是不用的
            // current记录本层的各个节点的最大值, 计算完毕后再覆盖到previous中

            // [0, 1-n-1, n]
            var previous = new int[n + 1];
            // [0-n]
            var current = new int[n];
            for (int i = 0; i < n; i++)
            {
                var level = pyramid[i];
                for (int j = 0; j < i + 1; j++)
                {
                    int left = previous[j] + level[j];
                    int right = previous[j + 1] + level[j];
                    current[j] = left > right ? left : right;
                }
                for (int j = 0; j < i + 1; j++)
                    previous[j + 1] = current[j];
            }

            int max = current.Max();
            return max;
        }
    }
}
