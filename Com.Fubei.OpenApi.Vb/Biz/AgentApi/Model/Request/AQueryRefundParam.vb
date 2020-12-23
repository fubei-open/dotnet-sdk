Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Request

    ' 退款查询
    ' http://docs.51fubei.com/agent-api/payment/orderRefundQuery.html
    Public Class AQueryRefundParam
        Inherits BaseEntity

        <JsonProperty("merchant_id")>
        Public Property MerchantId As Integer?

        <JsonProperty("refund_sn")>
        Public Property RefundSn As String

        <JsonProperty("merchant_refund_sn")>
        Public Property MerchantRefundSn As String
    End Class
End Namespace