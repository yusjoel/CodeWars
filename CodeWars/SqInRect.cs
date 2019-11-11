using System;
using System.Collections.Generic;

namespace CodeWars
{
    /// <summary>
    ///     Rectangle into Squares
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/rectangle-into-squares/train/csharp
    /// </remarks>
    public class SqInRect
    {
        /// <summary>
        ///     MySolution
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="wdth"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once IdentifierTypo
        public static List<int> sqInRect(int lng, int wdth)
        {
            if (lng == wdth)
                return null;

            int max = Math.Max(lng, wdth);
            int min = Math.Min(lng, wdth);
            var results = new List<int>();

            if (min == 1)
            {
                for (int i = 0; i < max; i++)
                    results.Add(min);
                return results;
            }

            results.Add(min);

            int sub = max - min;
            if (sub == min)
            {
                results.Add(min);
                return results;
            }

            results.AddRange(sqInRect(sub, min));
            return results;
        }

        // 确实非递归的解法更好一些
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once IdentifierTypo
        public static List<int> sqInRect2(int lng, int wdth)
        {
            if (lng == wdth) return null;

            var squares = new List<int>();
            while (lng > 0 && wdth > 0)
                if (lng < wdth)
                {
                    squares.Add(lng);
                    wdth -= lng;
                }
                else
                {
                    squares.Add(wdth);
                    lng -= wdth;
                }
            return squares;
        }
    }
}
