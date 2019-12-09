using System;
using System.Collections.Generic;

namespace CodeWars.Kyu4
{
    /// <summary>
    ///     Factorial tail
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/factorial-tail/train/csharp
    /// </remarks>
    public class FactorialTail
    {
        // ReSharper disable once InconsistentNaming
        public static int zeroes(int baseNumber, int number)
        {
            // 对于base, 先做因式分解, 如10 = 2x5, 16 = 2^4, 13 = 13
            var baseNumberPrimeFactors = GetPrimeFactors(baseNumber);

            // 然后计算2~number中包含多少个因子
            int min = int.MaxValue;
            foreach (var pair in baseNumberPrimeFactors)
            {
                int f = pair.Key;
                int c = pair.Value;
                int n = number / f;
                int cnt = n;
                while (n > 1)
                {
                    n = n / f;
                    cnt += n;
                }

                cnt = cnt / c;
                if (cnt < min)
                    min = cnt;
            }

            return min;
        }

        private static Dictionary<int, int> GetPrimeFactors(int number)
        {
            var primes = new Dictionary<int, int>();

            do
            {
                bool found = false;
                int square = (int) Math.Sqrt(number);
                for (int i = 2; i <= square; i++)
                {
                    if (number % i != 0)
                        continue;

                    if (!primes.ContainsKey(i))
                        primes[i] = 1;
                    else
                        primes[i]++;
                    number /= i;
                    found = true;
                    break;
                }
                if (!found)
                {
                    if (!primes.ContainsKey(number))
                        primes[number] = 1;
                    else
                        primes[number]++;
                    break;
                }
            } while (number > 1);
            return primes;
        }
    }
}
