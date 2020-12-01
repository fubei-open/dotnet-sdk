using System;
using System.Collections;
using System.Collections.Generic;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Constants;
using Com.Illuminati.Galileo.Exceptions;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Illuminati.Galileo.Net.Interceptor
{
    /// <summary>
    /// 抽象付呗接口-付呗OpenAPI拦截器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbsFubeiOpenApiInterceptor<T> : FubeiApiInterceptor
    {
        public delegate void ResponsePreprocess(ref T response, RequestCarrier carrier);

        public delegate void ResponseExceptionProcess(Exception ex, RequestCarrier carrier);

        public ResponsePreprocess PreprocessResponseHandler;

        public ResponseExceptionProcess ProcessExceptionHandler;

        protected override object Execute(string host, ApiAttribute attr, Hashtable table, Type genericType)
        {
            if (attr == null)
            {
                throw new FubeiSdkException("接口未设置ApiAttribute");
            }
            var appConfig = GalileoApiConfig.Instance.GetApiConfig(attr.Category) ?? new GalileoApiConfig.ApiConfig();

            var param = new ApiRequestParam(attr)
            {
                AppId = appConfig.AppId,
                VendorSn = appConfig.VendorSn,
                BizContent = table.ContainsKey(ApiConstants.JsonTag)
                    ? table[ApiConstants.JsonTag].ToString()
                    : JsonConvert.SerializeObject(table, ApiConstants.JsonSerializerSettings)
            };

            var paramList = ConvertToKeyValueList(param, attr);
            // 根据vendorSn是否为空来确定使用AppSecret或者VendorSecret
            var secret = string.IsNullOrEmpty(appConfig.VendorSn) ? appConfig.AppSecret : appConfig.VendorSecret;

            var signature = SignatureGenerator.GetSign(paramList, p => p + secret);
            param.Signature = signature.Signature;
            paramList.Add(new KeyValuePair<string, object>(ApiConstants.Sign, signature.Signature));

            var data = DoRequest(host, attr, paramList);
            // 处理请求
            return AfterExecution(data, genericType, new RequestCarrier
            {
                Host = host,
                RequestMethod = param.Method
            });
        }

        protected abstract T DoRequest(string host, ApiAttribute attr, List<KeyValuePair<string, object>> paramList);

        protected abstract object AfterExecution(T data, Type genericType, RequestCarrier carrier);

        protected virtual List<KeyValuePair<string, object>> ConvertToKeyValueList(ApiRequestParam rp, Attribute attr)
        {
            var rk = string.IsNullOrEmpty(rp.VendorSn) ? ApiConstants.AppId : ApiConstants.VendorSn;
            var rs = string.IsNullOrEmpty(rp.VendorSn) ? rp.AppId : rp.VendorSn;

            return new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(rk, rs),
                new KeyValuePair<string, object>(ApiConstants.Format, rp.Format),
                new KeyValuePair<string, object>(ApiConstants.SignMethod, rp.SignMethod),
                new KeyValuePair<string, object>(ApiConstants.Method, rp.Method),
                new KeyValuePair<string, object>(ApiConstants.Nonce, rp.Nonce),
                new KeyValuePair<string, object>(ApiConstants.BizContent, rp.BizContent),
                new KeyValuePair<string, object>(ApiConstants.Version, rp.Version)
            };
        }
    }
}
