Imports Newtonsoft.Json

Namespace Biz.V2.Model.Response
    
    ' 定额码请求响应实体
    Public Class ACreateFixedQrcodeResultEntity
        <JsonProperty("qrcode_url")>
        Public Property QrcodeUrl As String

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String
    End Class
End Namespace
