Imports Com.Fubei.Api.OpenApi.Biz
Imports Com.Fubei.Api.OpenApi.Net.HttpClient
Imports Com.Illuminati.Galileo.Attr
Imports Com.Illuminati.Galileo.Constants
Imports Com.Illuminati.Galileo.Exceptions
Imports Com.Illuminati.Galileo.Model
Imports Com.Illuminati.Galileo.Net.Interceptor
Imports Newtonsoft.Json

Namespace Net.Interceptor
    Public Class FubeiOpenApiInterceptor
        Inherits AbsFubeiOpenApiInterceptor(Of OpenApiResponse)

        Protected Overrides Function GetApiHost() As String
            Return If(String.IsNullOrEmpty(OpenApiStorage.Instance.OpenApiHost), ApiConstants.FubeiOpenapiHost, OpenApiStorage.Instance.OpenApiHost)
        End Function

        Protected Overrides Function DoRequest(ByVal host As String, ByVal attr As ApiAttribute, ByVal paramList As List(Of KeyValuePair(Of String, Object))) As OpenApiResponse
            Return HttpClientFactory.HttpRequestForOpenApi.PostRequest(host, attr, paramList)
        End Function

        Protected Overrides Function AfterExecution(ByVal data As OpenApiResponse, ByVal genericType As Type, ByVal carrier As RequestCarrier) As Object
            If data.ResultCode = ApiConstants.SuccessCode Then
                Return JsonConvert.DeserializeObject(data.Data.ToString(), genericType)
            Else
                Throw New BizException(If(data.ResultCode, -9999), data.SubCode, data.ResultMessage, data.Data)
            End If
        End Function
    End Class
End Namespace
