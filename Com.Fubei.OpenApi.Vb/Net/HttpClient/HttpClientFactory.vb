Imports Com.Fubei.Api.OpenApi.Biz
Imports Com.Illuminati.Galileo.Net.HttpClient
Imports Com.Illuminati.Galileo.Net.HttpClient.Impl

Namespace Net.HttpClient
    Public Class HttpClientFactory
        Public Shared ReadOnly Property HttpRequestForOpenApi As IHttpRequest(Of OpenApiResponse) = New FubeiHttpRequestAdapter(Of RestSharpRequestImpl, OpenApiResponse)()
    End Class
End Namespace
