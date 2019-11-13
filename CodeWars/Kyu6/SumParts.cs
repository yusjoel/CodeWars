using System;

namespace CodeWars.Kyu6
{
    /// <summary>
    ///     Sums of Parts
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/5ce399e0047a45001c853c2b
    /// </remarks>
    public class SumParts
    {
        public static int[] PartsSums(int[] ls)
        {
            if (ls == null)
                throw new ArgumentNullException(nameof(ls));

            int length = ls.Length;
            var sums = new int[length + 1];

            checked
            {
                try
                {
                    int sum = 0;
                    sums[length] = 0;
                    for (int i = length - 1; i >= 0; i--)
                    {
                        sum += ls[i];
                        sums[i] = sum;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return sums;
        }
    }
}
