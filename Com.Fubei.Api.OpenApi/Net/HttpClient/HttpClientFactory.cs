using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Biz.MerchantApi;
using Com.Illuminati.Galileo.Net.HttpClient.Impl;

namespace Com.Illuminati.Galileo.Net.HttpClient
{
    public class HttpClientFactory
    {
        public static IHttpRequest<OpenApiResponse> HttpRequestForOpenApi { get; } = new FubeiHttpRequestAdapter<RestSharpRequestImpl, OpenApiResponse>();
    }
}
