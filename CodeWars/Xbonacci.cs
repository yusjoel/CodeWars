using System;

namespace CodeWars
{
    public class Xbonacci
    {
        public double[] Tribonacci(double[] signature, int n)
        {
            if (signature == null)
                throw new ArgumentNullException(nameof(signature));

            if (signature.Length < 3)
                throw new ArgumentException("Signature will always contain 3 numbers", nameof(signature));

            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "n must bigger then zero, current is " + n);

            var result = new double[n];
            int i = 0;
            for (; i < signature.Length && i < n; i++)
                result[i] = signature[i];

            for (; i < n; i++)
                result[i] = result[i - 3] + result[i - 2] + result[i - 1];

            return result;
        }
    }
}
