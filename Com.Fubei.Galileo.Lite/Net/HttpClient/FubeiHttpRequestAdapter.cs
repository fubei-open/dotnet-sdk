using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Net.Interceptor;
using Newtonsoft.Json;
using RestSharp;

// https://github.com/Real-Serious-Games/C-Sharp-Promise

namespace Com.Illuminati.Galileo.Net.HttpClient
{
    /// <summary>
    /// 付呗接口请求适配器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    public class FubeiHttpRequestAdapter<T, TE> : IHttpRequest<TE> where T : IHttpRequest, new()
    {
        private T _rawRequest = new T();

        public IWebProxy WebProxy
        {
            get => _rawRequest.WebProxy;
            set => _rawRequest.WebProxy = value;
        }

        public FubeiHttpRequestAdapter<T, TE> SetWebProxy(IWebProxy webProxy)
        {
            this.WebProxy = webProxy;
            return this;
        }

        public TE PostRequest(string host, ApiAttribute attr, IEnumerable<KeyValuePair<string, object>> paramList)
        {
            var p = _rawRequest.PostRequest(host, attr, paramList);
            return JsonConvert.DeserializeObject<TE>(p);
        }

        public void AddCustomHeader(IEnumerable<KeyValuePair<string, string>> headerList)
        {
            _rawRequest.AddCustomHeader(headerList);
        }
    }
}
