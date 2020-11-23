using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Com.Illuminati.Galileo.Utils
{
    public class RandomStringUtil
    {
        private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] Numeric = "0123456789".ToCharArray();

        /// <summary>
        /// 生成随机串
        /// </summary>
        /// <param name="cnt">随机串长度</param>
        /// <returns></returns>
        public static string NewRandomString(int cnt)
        {
            return NewRandomStringInternal(cnt, Alphabet);
        }

        /// <summary>
        /// 生成随机数字字符串
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public static string NewNumericString(int cnt)
        {
            return NewRandomStringInternal(cnt, Numeric);
        }

        private static string NewRandomStringInternal(int cnt, IList<char> phase)
        {
            if (cnt == 0 || phase == null)
            {
                return string.Empty;
            }
            var sb = new StringBuilder(cnt);
            var len = phase.Count;
            for (var i = 0; i != cnt; ++i)
            {
                sb.Append(phase[new Random(GuidSeed()).Next(len)]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 随机数种子
        /// </summary>
        /// <returns></returns>
        private static int GuidSeed()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }

}
