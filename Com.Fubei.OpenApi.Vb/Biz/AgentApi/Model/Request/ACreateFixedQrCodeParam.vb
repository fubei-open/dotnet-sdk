Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Request
    
    ' 定额码支付
    ' http://docs.51fubei.com/agent-api/payment/orderQrPay.html
    Public Class ACreateFixedQrCodeParam
        Inherits BaseEntity

        <JsonProperty("merchant_id")>
        Public Property MerchantId As Integer?

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("total_amount")>
        Public Property TotalAmount As Decimal

        <JsonProperty("store_id")>
        Public Property StoreId As Integer

        <JsonProperty("sub_appid")>
        Public Property SubAppId As String

        <JsonProperty("user_id")>
        Public Property UserId As String

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

        <JsonProperty("expired_time")>
        Public Property ExpiredTime As Integer = 600

    End Class
End Namespace
