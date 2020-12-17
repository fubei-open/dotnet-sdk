Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Request
    
    ' 付款码支付
    ' http://docs.51fubei.com/agent-api/payment/orderPay.html
    Public Class AOrderPayParam
        Inherits BaseEntity

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("merchant_id")>
        Public Property MerchantId As Integer?

        <JsonProperty("auth_code")>
        Public Property AuthCode As String

        <JsonProperty("total_amount")>
        Public Property TotalAmount As Decimal

        <JsonProperty("store_id")>
        Public Property StoreId As Integer?

        <JsonProperty("cashier_id")>
        Public Property CashierId As Integer?

        <JsonProperty("sub_appid")>
        Public Property SubAppId As String

        <JsonProperty("goods_tag")>
        Public Property GoodsTag As String

        <JsonProperty("detail")>
        Public Property Detail As GoodsDetailEntity

        <JsonProperty("device_no")>
        Public Property DeviceNo As String
        <JsonProperty("body")>
        Public Property Body As String

        <JsonProperty("attach")>
        Public Property Attach As String

        <JsonProperty("timeout_express")>
        Public Property TimeoutExpress As String

        <JsonProperty("notify_url")>
        Public Property NotifyUrl As String

        <JsonProperty("alipay_extend_params")>
        Public Property AlipayExtendParams As AlipayExtendParamsEntity
    End Class
End Namespace
