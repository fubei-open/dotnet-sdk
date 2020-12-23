Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Request
    
    Public Class AOrderClosureParam
        Inherits BaseEntity

        <JsonProperty("merchant_id")>
        Public Property MerchantId As Integer?

        <JsonProperty("order_sn")>
        Public Property OrderSn As String

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String
    End Class
End Namespace
