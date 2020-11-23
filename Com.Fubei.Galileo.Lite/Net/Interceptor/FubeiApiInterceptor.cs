using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using Com.Illuminati.Galileo.Attr;

namespace Com.Illuminati.Galileo.Net.Interceptor
{
    /// <summary>
    /// 抽象付呗接口-通用接口拦截器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FubeiApiInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var invocationInfo = CheckInvocation(invocation);
            var paramTab = new Hashtable();
            if (invocationInfo.ParameterInfos != null)
            {
                for (var i = 0; i != invocationInfo.ParameterInfos.Length; ++i)
                {
                    FubeiParamParser.ParseToHashtable(invocationInfo.ParameterInfos[i], invocation.Arguments[i], ref paramTab);
                }
            }
            // 参数   
            var host = GetApiHost();

            // 创建请求Promise，返回response
            invocation.ReturnValue = Execute(host, invocationInfo.ApiAttribute, paramTab, invocation.Method.ReturnType);
        }

        protected abstract string GetApiHost();

        protected abstract object Execute(string host, ApiAttribute attr, Hashtable table, Type genericType);

        private static InvocationInfo CheckInvocation(IInvocation invocation)
        {
            var apiAttr = FubeiParamParser.GetApiAttribute(invocation.Method);
            var parameters = invocation.Method.GetParameters();

            //var returnType = invocation.Method.ReturnType;

            //if (returnType.GetGenericTypeDefinition() != typeof(Promise<>) && returnType.GetGenericTypeDefinition() != typeof(IPromise<>))
            //{
            //    throw new ArgumentException("抽象接口Api返回的类型必须为Promise<>或IPromise<>");
            //}
            // 限定该拦截器中生成的对象返回时Promise

            return new InvocationInfo
            {
                ApiAttribute = apiAttr,
                ParameterInfos = parameters
            };
        }
    }
}
