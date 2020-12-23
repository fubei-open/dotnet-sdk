Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V2.Model.Request
    
    ' 统一下单
    ' http://docs.51fubei.com/agent-api/payment/orderCreate.html
    Public Class AOrderCreateParam
        Inherits BaseEntity

        ' 外部系统订单号
        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        ' 付呗商户号，以服务商级接入时必传，以商户级接入时不传
        <JsonProperty("merchant_id")>
        Public Property MerchantId As Integer?

        ' 支付方式，wxpay 微信，alipay 支付宝
        <JsonProperty("pay_type")>
        Public Property PayType As String

        ' 订单总金额，单位为元，精确到0.01 ~ 10000000
        <JsonProperty("total_amount")>
        Public Property TotalAmount As Decimal

        ' 商户门店号
        <JsonProperty("store_id")>
        Public Property StoreId As Integer?

        ' 收银员ID
        <JsonProperty("cashier_id")>
        Public Property CashierId As Integer?

        ' 公众号appid。当微信支付时，该字段必填（user_id需要保持一致，即为该公众号appid获取的）
        ' 间联商户需提前配置对应公众号appid，对应配置接口
        <JsonProperty("sub_appid")>
        Public Property SubAppId As String

        ' 用户标识（微信openid，支付宝userid）
        <JsonProperty("user_id")>
        Public Property UserId As String

        ' 订单优惠标记，代金券或立减优惠功能的参数（使用单品券时必传）
        <JsonProperty("goods_tag")>
        Public Property GoodsTag As String

        ' 订单包含的商品信息，Json格式。当当微信支付或者支付宝支付时时可选填此字段。对于使用单品优惠的商户，该字段必须按照规范上传，详见“单品优惠参数说明”
        <JsonProperty("detail")>
        Public Property Detail As GoodsDetailEntity

        ' 终端号
        <JsonProperty("device_no")>
        Public Property DeviceNo As String

        ' 商品描述
        <JsonProperty("body")>
        Public Property Body As String

        ' 附加数据，原样返回，该字段主要用于商户携带订单的自定义数据
        <JsonProperty("attach")>
        Public Property Attach As String

        ' 订单失效时间，逾期将关闭交易。格式为yyyyMMddHHmmss，失效时间需大于1分钟。银联暂不支持
        <JsonProperty("timeout_express")>
        Public Property TimeoutExpress As String

        ' 支付回调地址
        <JsonProperty("notify_url")>
        Public Property NotifyUrl As String

        ' 支付宝业务拓展参数--花呗分期
        <JsonProperty("alipay_extend_params")>
        Public Property AlipayExtendParams As AlipayExtendParamsEntity
    End Class
End Namespace
