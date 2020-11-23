using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Com.Illuminati.Galileo.Utils
{
    /// <summary>
    /// 敏感字段管理器
    /// </summary>
    public class SensitiveKeywordManager
    {
        private readonly Dictionary<string, Regex> _sensitiveKeywords = new Dictionary<string, Regex>();

        private SensitiveKeywordManager()
        { 
        }

        public static SensitiveKeywordManager Instance = new SensitiveKeywordManager();

        public bool MaskSensitiveKeyword => _sensitiveKeywords.Count != 0;

        public const string ElasticMask = "********";

        /// <summary>
        /// 添加敏感关键字
        /// </summary>
        /// <param name="keyword"></param>
        public void AddKeywords(params string[] keyword)
        {
            foreach (var item in keyword)
            {
                _sensitiveKeywords.Add(item, new Regex($"\"{item}\":\".*\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace));
            }
        }

        public string ReplaceSensitive(string str)
        {
            if (string.IsNullOrEmpty(str) || MaskSensitiveKeyword)
            {
                return str;
            }

            var ret = str;
            foreach (var sensitiveKeyword in _sensitiveKeywords)
            {
                ret = sensitiveKeyword.Value.Replace(ret, $"\"{sensitiveKeyword.Key}\":\"{ElasticMask}\"");
            }

            return ret;
        }
    }
}
