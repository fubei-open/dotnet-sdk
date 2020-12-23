
Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Response
    Public Class AOrderClosureResultEntity
        Inherits BaseEntity

        <JsonProperty("merchant_id")>
        Public Property MerchantId As String

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("order_status")>
        Public Property OrderStatus As String

    End Class
End Namespace