using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Constants;
using Com.Illuminati.Galileo.Exceptions;
using Com.Illuminati.Galileo.Foundation;
using Com.Illuminati.Galileo.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace Com.Illuminati.Galileo.Net.HttpClient.Impl
{
    public class RestSharpRequestImpl : IHttpRequest
    {
        public IWebProxy WebProxy { get; set; } = null;

        /// <summary>
        /// 自定义请求头
        /// </summary>
        private readonly Dictionary<string, string> _customHeaders = new Dictionary<string, string>();

        public string PostRequest(string host, ApiAttribute attr, IEnumerable<KeyValuePair<string, object>> paramList)
        {
            // 创建Promise
            Uri uri = new Uri(host);
            var restClient = new RestClient
            {
                BaseUrl = uri,
                UserAgent = UserAgentUtil.Instance.FinaleValue
            };
            // 设置WebProxy
            restClient.Proxy = WebProxy;
            // 设置参数
            var request = new RestRequest(attr.Path, Method.POST)
            {
                Timeout = attr.Timeout * 1000
            };
            // 设置请求头
            foreach (var keyValuePair in _customHeaders)
            {
                request.AddHeader(keyValuePair.Key, keyValuePair.Value);
            }

            // 请求的追踪ID，同一个请求和响应的追踪ID是相同的
            var traceId = TraceIdGenerator.NewTraceId();
            var remark =
                $"HttpClient=RestSharp^TraceId={traceId}^Host={GalileoApiConfig.Instance.LoggerProcMaskHost?.Invoke(host) ?? host}^Method={attr.Method}";
            switch (attr.Format)
            {
                // json格式，CashierApi/开放平台使用
                case ApiConstants.Json:
                    {
                        var json = SensitiveKeywordManager.Instance.ReplaceSensitive(AddJsonBody(request, paramList));
                        GalileoLogger.Instance.Debug(
                            $"Action=SendRequest^Format=JSON^{remark}^Format=Json^Body={json.Replace("\\\"", "'")}");
                        break;
                    }

                // 默认Form格式，CashierGw使用
                default:
                    {
                        var sb = new StringBuilder();
                        foreach (var param in paramList)
                        {
                            if (param.Value == null) continue;
                            request.AddParameter(param.Key, param.Value);
                            if (sb.Length != 0)
                            {
                                sb.Append("&");
                            }

                            sb.Append($"{param.Key}:({param.Value})");
                        }

                        GalileoLogger.Instance.Debug(
                            $"Action=SendRequest^Format=FORM^{remark}^Format=Form^Body={{{sb}}})");
                        break;
                    }
            }

            var startTick = Environment.TickCount;
            var response = restClient.Execute(request);
            var content = $"{response.Content}";
            if (response.StatusCode != HttpStatusCode.OK)
            {
                content = string.IsNullOrEmpty(response.Content) ? "网络错误，请检查网络连接" : $"网络错误：{response.Content}";
            }

            GalileoLogger.Instance.Debug(
                $"Action=GetResponse^{remark}^Duration={Environment.TickCount - startTick}^StatusCode={response.StatusCode}^Status={response.ResponseStatus}^Body={content}");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpException(Convert.ToInt32(response.StatusCode),
                    response.StatusDescription, (int)response.ResponseStatus, content, response.ErrorException);
            }
            return response.Content;

        }

        public void AddCustomHeader(IEnumerable<KeyValuePair<string, string>> headerList)
        {
            foreach (var item in headerList)
            {
                if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value))
                {
                    _customHeaders[item.Key] = item.Value;
                }
            }
        }

        private static string AddJsonBody(IRestRequest request, IEnumerable<KeyValuePair<string, object>> obj)
        {
            var json = JsonConvert.SerializeObject(obj.ToDictionary(p => p.Key, p => p.Value));
            // RestSharp使用AddBody或者AddJsonBody需传入原始对象，但我们目前需要记录JSON，所以只能使用此方法
            request.AddParameter(ApiConstants.ApplicationJson, json, ParameterType.RequestBody);
            return json;
        }
    }
}
