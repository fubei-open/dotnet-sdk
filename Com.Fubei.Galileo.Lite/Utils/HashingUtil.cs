using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Com.Illuminati.Galileo.Utils
{
    internal class HashingUtil
    {
        public static string Md5(string str, bool upperCase = true)
        {
            var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(str);
            var buf = md5.ComputeHash(bytes);
            var builder = new StringBuilder();
            foreach (var num in buf)
            {
                builder.Append(num.ToString(upperCase ? "X2" : "x2"));
            }
            return builder.ToString();
        }
    }
}
