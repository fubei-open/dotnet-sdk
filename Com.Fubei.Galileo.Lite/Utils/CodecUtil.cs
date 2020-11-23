using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Illuminati.Galileo.Utils
{
    internal class CodecUtil
    {
        private const string UnreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        /// <summary>
        /// 做Oauth UrlEncode 比普通urlencode多几步
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlEncode(string value)
        {
            return UrlEncode(value, Encoding.UTF8);
        }

        public static string UrlEncode(string value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);
            var sb = new StringBuilder();
            foreach (var p in bytes)
            {
                var c = Convert.ToChar(p);
                if (UnreservedChars.IndexOf(c) != -1)
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append($"%{(int) c:X2}");
                }
            }
            return sb.ToString();
        }
    }
}
