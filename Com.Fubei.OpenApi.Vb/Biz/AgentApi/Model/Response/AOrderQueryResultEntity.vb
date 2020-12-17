Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Response
    
    ' 订单查询请求响应实体
    Public Class AOrderQueryResultEntity
        Inherits BaseEntity

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("order_sn")>
        Public Property OrderSn As String

        <JsonProperty("ins_order_sn")>
        Public Property InsOrderSn As String

        <JsonProperty("channel_order_sn")>
        Public Property ChannelOrderSn As String

        <JsonProperty("order_status")>
        Public Property OrderStatus As String

        <JsonProperty("pay_type")>
        Public Property PayType As String

        <JsonProperty("total_amount")>
        Public Property TotalAmount As Decimal

        <JsonProperty("net_amount")>
        Public Property NetAmount As Decimal?

        <JsonProperty("buyer_pay_amount")>
        Public Property BuyerPayAmount As Decimal?

        <JsonProperty("fee")>
        Public Property Fee As Decimal?

        <JsonProperty("store_id")>
        Public Property StoreId As Integer

        <JsonProperty("cashier_id")>
        Public Property CashierId As Integer

        <JsonProperty("user_id")>
        Public Property UserId As String

        <JsonProperty("finish_time")>
        Public Property FinishTime As String

        <JsonProperty("device_no")>
        Public Property DeviceNo As String

        <JsonProperty("attach")>
        Public Property Attach As String

        <JsonProperty("payment_list")>
        Public Property PaymentList As List(Of APaymentItemEntity)

        <JsonProperty("alipay_extend_params")>
        Public Property AlipayExtendParams As AlipayExtendParamsEntity
    End Class
End Namespace
