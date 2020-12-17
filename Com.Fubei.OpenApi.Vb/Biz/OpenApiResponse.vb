Imports Newtonsoft.Json
Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json.Linq

Namespace Biz
    ' OpenApi返回对象泛型类，1.0和2.0接口
    Public Class OpenApiResponse(Of T)
        Inherits BaseEntity

        <JsonProperty("result_code")>
        Public Property ResultCode As Integer?
        <JsonProperty("sub_code")>
        Public Property SubCode As String
        <JsonProperty("result_message")>
        Public Property ResultMessage As String
        <JsonProperty("data")>
        Public Property Data As T
    End Class

    Public Class OpenApiResponse
        Inherits OpenApiResponse(Of JToken)
    End Class
End Namespace