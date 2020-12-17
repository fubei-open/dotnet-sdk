Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Request
    
    ' 订单查询
    ' http://docs.51fubei.com/agent-api/payment/orderQuery.html
    Public Class AOrderQueryParam
        Inherits BaseEntity

        <JsonProperty("merchant_id")>
        Public Property MerchantId As Integer?

        <JsonProperty("order_sn")>
        Public Property OrderSn As String

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("ins_order_sn")>
        Public Property InsOrderSn As String
    End Class
End Namespace
