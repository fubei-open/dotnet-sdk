using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Fubei.Api.OpenApi;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Biz.MerchantApi;
using Com.Illuminati.Galileo.Constants;
using Com.Illuminati.Galileo.Exceptions;
using Com.Illuminati.Galileo.Model;
using Com.Illuminati.Galileo.Net.HttpClient;
using Com.Illuminati.Galileo.Utils;
using Newtonsoft.Json;

namespace Com.Illuminati.Galileo.Net.Interceptor
{
    public class FubeiOpenApiInterceptor : AbsFubeiOpenApiInterceptor<OpenApiResponse>
    {
        protected override string GetApiHost()
        {
            return string.IsNullOrEmpty(OpenApiStorage.Instance.OpenApiHost) ? 
                ApiConstants.FubeiOpenapiHost : OpenApiStorage.Instance.OpenApiHost;
        }

        protected override OpenApiResponse DoRequest(string host, ApiAttribute attr, List<KeyValuePair<string, object>> paramList)
        {
            return HttpClientFactory.HttpRequestForOpenApi.PostRequest(host, attr, paramList);
        }

        protected override object AfterExecution(OpenApiResponse data, Type genericType, RequestCarrier carrier)
        {
            if (data.ResultCode == ApiConstants.SuccessCode)
            {
                // 数据解析
                return JsonConvert.DeserializeObject(data.Data.ToString(), genericType);
            }
            else
            {
                //ReflectionUtil.Invoke(returnValue, ApiConstants.Reject,
                //    new object[] { new BizException(data.ResultCode ?? -9999, data.SubCode, data.ResultMessage, data.Data) });
                throw new BizException(data.ResultCode ?? -9999, data.SubCode, data.ResultMessage, data.Data);
            }
        }
    }
}
