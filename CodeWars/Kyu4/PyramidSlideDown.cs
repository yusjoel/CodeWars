using System;

namespace CodeWars.Kyu4
{
    /// <summary>
    ///     Pyramid Slide Down
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/pyramid-slide-down/train/csharp
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

            // 对于第i层的节点j, 总是选择第i+1层的节点j与节点j+1中较大的一个
            // 从底部向上按此规则计算, 到顶部后即为解

            var floor = new int[n + 1];
            for (int i = n - 1; i >= 0; i--)
            for (int j = 0; j < i + 1; j++)
                floor[j] = pyramid[i][j] + (floor[j] > floor[j + 1] ? floor[j] : floor[j + 1]);

            return floor[0];
        }
    }
}
