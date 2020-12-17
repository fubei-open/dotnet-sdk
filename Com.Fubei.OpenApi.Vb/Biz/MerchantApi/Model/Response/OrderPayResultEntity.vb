Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V1.Model.Response
    Public Class OrderPayResultEntity
        Inherits BaseEntity

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("order_sn")>
        Public Property OrderSn As String

        <JsonProperty("trade_no")>
        Public Property TradeNo As String

        <JsonProperty("trade_state")>
        Public Property TradeState As String

        <JsonProperty("total_fee")>
        Public Property TotalFee As Decimal

        <JsonProperty("order_price")>
        Public Property OrderPrice As Decimal

        <JsonProperty("pay_time")>
        Public Property PayTime As Integer

        <JsonProperty("type")>
        Public Property Type As Integer?

        <JsonProperty("discount_money")>
        Public Property DiscountMoney As Decimal?

        <JsonProperty("buyer_pay_amount")>
        Public Property BuyerPayAmount As Decimal?

        <JsonProperty("attach")>
        Public Property Attach As String

        <JsonProperty("store_id")>
        Public Property StoreId As Integer

        <JsonProperty("cashier_id")>
        Public Property CashierId As Integer?

        <JsonProperty("device_no")>
        Public Property DeviceNo As String

        <JsonProperty("body")>
        Public Property Body As String

        <JsonProperty("user_id")>
        Public Property UserId As String

        <JsonProperty("user_logon_id")>
        Public Property UserLogonId As String

        <JsonProperty("cash_coupon_fee")>
        Public Property CashCouponFee As Decimal?

        <JsonProperty("no_cash_coupon_fee")>
        Public Property NoCashCouponFee As Decimal?

        <JsonProperty("fee")>
        Public Property Fee As Decimal?

        <JsonProperty("platform_order_no")>
        Public Property PlatformOrderNo As String
    End Class
End Namespace
