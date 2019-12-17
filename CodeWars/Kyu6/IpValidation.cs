using System.Net;
using System.Text.RegularExpressions;

namespace CodeWars
{
    /// <summary>
    ///     IP Validation
    /// </summary>
    /// <remarks>https://www.codewars.com/kata/ip-validation/train/csharp</remarks>
    public class IpValidation
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool is_valid_IP(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                return false;

            var substrings = ipAddress.Split('.');
            if (substrings.Length != 4)
                return false;

            foreach (string substring in substrings)
            {
                int i;
                if (!int.TryParse(substring, out i))
                    return false;

                if (i > 255 || i < 0)
                    return false;

                if (substring != i.ToString())
                    return false;
            }

            return true;
        }

        public static bool is_valid_IP2(string ipAddress)
        {
            // 这个解可能最符合题意
            string regexPattern =
                "^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            return Regex.IsMatch(ipAddress, regexPattern);
        }

        public static bool is_valid_IP3(string ipAddress)
        {
            // 其实我的代码也不比这个好到哪里
            bool validIp = IPAddress.TryParse(ipAddress, out var ip);
            return validIp && ip.ToString() == ipAddress;
        }
    }
}
