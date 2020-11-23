using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Illuminati.Galileo.Utils
{
    /// <summary>
    /// TraceId 生成
    /// 所有的请求、响应会生成一个TraceId，用于追踪请求日志
    /// </summary>
    public sealed class TraceIdGenerator
    {
        static TraceIdGenerator()
        {
            NewTraceId = NewRandomString;
        }

        public delegate string GenerateTraceId();

        /// <summary>
        /// 可设置自己规则的TraceId生成规则
        /// </summary>
        public static GenerateTraceId NewTraceId { get; set; }

        private static string NewRandomString()
        {
            return RandomStringUtil.NewRandomString(8);
        }
    }
}
