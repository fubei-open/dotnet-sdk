using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Com.Fubei.Api.OpenApi.Biz.AgentApi;
using Com.Fubei.Api.OpenApi.Biz.MerchantApi;
using Com.Illuminati.Galileo.Net.Interceptor;

namespace Com.Illuminati.Galileo.Biz
{
    public sealed class FubeiOpenApiFactory
    {
        static FubeiOpenApiFactory()
        {
            var proxyGenerator = new ProxyGenerator();
            MerchantApi = proxyGenerator.CreateInterfaceProxyWithoutTarget<IFubeiMerchantApi>(ProxyGenerationOptions.Default, new FubeiOpenApiInterceptor());
            AgentApi = proxyGenerator.CreateInterfaceProxyWithoutTarget<IFubeiAgentApi>(ProxyGenerationOptions.Default, new FubeiOpenApiInterceptor());
        }

        /// <summary>
        /// 开放平台1.0接口
        /// </summary>
        public static IFubeiMerchantApi MerchantApi { get; }


        /// <summary>
        /// 开放平台2.0接口
        /// </summary>
        public static IFubeiAgentApi AgentApi { get; }
    }
}
