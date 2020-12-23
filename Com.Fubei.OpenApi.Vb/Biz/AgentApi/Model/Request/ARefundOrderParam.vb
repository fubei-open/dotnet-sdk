Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Request
    Public Class ARefundOrderParam
        Inherits BaseEntity
        
        <JsonProperty("merchant_id")>
        Public Property MerchantId As Integer?

        <JsonProperty("order_sn")>
        Public Property OrderSn As String

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("ins_order_sn")>
        Public Property InsOrderSn As String

        <JsonProperty("merchant_refund_sn")>
        Public Property MerchantRefundSn As String

        <JsonProperty("refund_amount")>
        Public Property RefundAmount As Decimal

        <JsonProperty("handler")>
        Public Property Handler As Integer?
    End Class

End Namespace
