using System;
using System.Collections.Generic;

namespace CodeWars.Kyu6
{
    /// <summary>
    ///     Find the odd int
    /// </summary>
    /// <remarks>https://www.codewars.com/kata/find-the-odd-int/train/csharp</remarks>
    public class Kata002
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        // ReSharper disable once UnusedMember.Global
        public static int find_it(int[] seq)
        {
            if (seq == null)
                throw new ArgumentNullException(nameof(seq));

            var result = new List<int>();

            foreach (int i in seq)
                if (result.Contains(i))
                    result.Remove(i);
                else
                    result.Add(i);

            if (result.Count == 1)
                return result[0];

            throw new ArgumentException("wrong sequence");
        }

        /// <summary>
        ///     Clever
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        public static int find_it2(int[] seq)
        {
            int found = 0;

            foreach (int num in seq)
                found ^= num;

            return found;
        }
    }
}
