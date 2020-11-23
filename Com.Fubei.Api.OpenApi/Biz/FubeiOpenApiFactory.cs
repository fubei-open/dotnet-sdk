using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Com.Illuminati.Galileo.Biz.MerchantApi;
using Com.Illuminati.Galileo.Net.Interceptor;

namespace Com.Illuminati.Galileo.Biz
{
    public sealed class FubeiOpenApiFactory
    {
        static FubeiOpenApiFactory()
        {
            var proxyGenerator = new ProxyGenerator();
            MerchantApi = proxyGenerator.CreateInterfaceProxyWithoutTarget<IFubeiMerchantApi>(ProxyGenerationOptions.Default, new FubeiOpenApiInterceptor());
        }

        public static IFubeiMerchantApi MerchantApi { get; }
    }
}
