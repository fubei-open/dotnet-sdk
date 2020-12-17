Imports Castle.DynamicProxy
Imports Com.Fubei.Api.OpenApi.Biz.V1
Imports Com.Fubei.Api.OpenApi.Biz.V2
Imports Com.Fubei.Api.OpenApi.Net.Interceptor

Namespace Biz

    ' 开放平台接口工厂类
    Public NotInheritable Class FubeiOpenApiFactory
        Shared Sub New()
            Dim proxyGenerator = New ProxyGenerator()
            MerchantApi = proxyGenerator.CreateInterfaceProxyWithoutTarget(Of IFubeiMerchantApi)(ProxyGenerationOptions.Default, New FubeiOpenApiInterceptor())
            AgentApi = proxyGenerator.CreateInterfaceProxyWithoutTarget(Of IFubeiAgentApi)(ProxyGenerationOptions.Default, New FubeiOpenApiInterceptor())
        End Sub

        ' 开放平台1.0接口
        Public Shared ReadOnly Property MerchantApi As IFubeiMerchantApi

        ' 开放平台2.0接口
        Public Shared ReadOnly Property AgentApi As IFubeiAgentApi
    End Class
End Namespace
