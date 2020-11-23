using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Com.Illuminati.Galileo.Constants;
using Com.Illuminati.Galileo.Utils;

namespace Com.Illuminati.Galileo
{
    public class GalileoApiConfig
    {
        public enum Category
        {
            CashierApi,
            CashierGwApi,
            MerchantApi,
            AgentApi
        }
        
        public static GalileoApiConfig Instance = new GalileoApiConfig();

        private readonly Dictionary<string, ApiConfig> _apiConfigInfo = new Dictionary<string, ApiConfig>();

        public WebProxy WebProxy { get; set; }

        public Func<string, string> LoggerProcMaskHost { get; set; }

        /// <summary>
        /// 添加敏感字段过滤
        /// </summary>
        /// <param name="keywords"></param>
        public void AddSensitiveKeyword(params string[] keywords)
        {
            SensitiveKeywordManager.Instance.AddKeywords(keywords);
        }

        public TraceIdGenerator.GenerateTraceId GenerateTraceId
        {
            get => TraceIdGenerator.NewTraceId;
            set => TraceIdGenerator.NewTraceId = value;
        }

        public class ApiConfig
        {
            public string AppId { get; set; }
            public string AppSecret { get; set; }
        }

        private static string GetIdentifier(string key)
        {
            var id = string.IsNullOrEmpty(key) ? string.Empty : "." + key;
            return $"{ApiConstants.KeyApiconfig}{id}";
        }

        public void Register(ApiConfig config, Category category = Category.CashierApi)
        {
            _apiConfigInfo[GetIdentifier(category.ToString())] = config;
        }

        public ApiConfig GetApiConfig(Category category = Category.MerchantApi)
        {
            var id = GetIdentifier(category.ToString());
            return _apiConfigInfo.ContainsKey(id) ? _apiConfigInfo[id] : null;
        }
    }
}
