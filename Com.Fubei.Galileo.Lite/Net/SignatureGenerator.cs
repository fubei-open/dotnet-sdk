using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Constants;
using Com.Illuminati.Galileo.Model;
using Com.Illuminati.Galileo.Utils;

namespace Com.Illuminati.Galileo.Net
{
    public class SignatureGenerator
    {
        public delegate IEnumerable<KeyValuePair<string, object>> ParamListGenerateDelegate(ApiRequestParam param);

        public delegate string BaseStringPreprocessingDelegate(string baseString);

        public class SignatureBody
        {
            public static readonly SignatureBody Nil = new SignatureBody();
            public string Signature { get; set; } = string.Empty;
            public string BaseString { get; set; } = string.Empty;
        }
        
        public static SignatureBody GetSign(List<KeyValuePair<string, object>> paramList, BaseStringPreprocessingDelegate baseStringPreprocessing = null)
        {
            if (paramList == null)
            {
                return SignatureBody.Nil;
            }

            var baseString = GetBaseString(paramList, false, baseStringPreprocessing);
            // 获得签名
            var body = new SignatureBody
            {
               Signature = HashingUtil.Md5(baseString),
               BaseString = baseString
            };
            return body;
        }

        private static string GetBaseString(IEnumerable<KeyValuePair<string, object>> paramList, bool urlEncode = false, BaseStringPreprocessingDelegate baseStringPreprocessing = null)
        {
            var sb = new StringBuilder();
            paramList.OrderBy(p => p.Key).Select(p =>
            {
                var k = urlEncode ? CodecUtil.UrlEncode(p.Key) : p.Key;
                var v = urlEncode ? CodecUtil.UrlEncode(p.Value.ToString()) : p.Value;
                return $"{k}={v}";
            }).ToList().ForEach(p =>
                {
                    if (sb.Length != 0)
                    {
                        sb.Append("&");
                    }
                    sb.Append(p);
                });
            var str = sb.ToString();
            return baseStringPreprocessing != null ? baseStringPreprocessing(str) : str;
        }
    }
}
