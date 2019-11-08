using System;
using System.Linq;

namespace CodeWars
{
    public class Sum
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetSum(int a, int b)
        {
            if (a <= b)
            {
                int sum = 0;
                for (int i = a; i <= b; i++)
                    sum += i;
                return sum;
            }

            return GetSum(b, a);
        }

        public int GetSum2(int a, int b)
        {
            return (Math.Abs(b - a) + 1) * (a + b) / 2;
        }

        public int GetSum3(int a, int b)
        {
            return Enumerable.Range(Math.Min(a, b), Math.Abs(b - a) + 1).Sum();
        }
    }
}
