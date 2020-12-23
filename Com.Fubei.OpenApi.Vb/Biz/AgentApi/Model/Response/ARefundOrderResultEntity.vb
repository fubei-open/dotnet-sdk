Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Response

    Public Class ARefundOrderResultEntity
        Inherits BaseEntity

        <JsonProperty("order_sn")>
        Public Property OrderSn As String
        <JsonProperty("refund_sn")>
        Public Property RefundSn As String
        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String
        <JsonProperty("merchant_refund_sn")>
        Public Property MerchantRefundSn As String
        <JsonProperty("refund_amount")>
        Public Property RefundAmount As Decimal
        <JsonProperty("refund_status")>
        Public Property RefundStatus As String
        <JsonProperty("finish_time")>
        Public Property FinishTime As String
        <JsonProperty("handler")>
        Public Property Handler As Integer?
    End Class

End Namespace