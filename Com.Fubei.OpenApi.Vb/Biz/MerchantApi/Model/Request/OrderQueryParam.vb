Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V1.Model.Request
    Public Class OrderQueryParam
        Inherits BaseEntity

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String
        
        <JsonProperty("order_sn")>
        Public Property OrderSn As String

        <JsonProperty("device_no")>
        Public Property DeviceNo As String
    End Class
End Namespace
