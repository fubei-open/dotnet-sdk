Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

' 公共类
Namespace Biz.V2.Model
    
    Public Class GoodsDetailEntity
        Inherits BaseEntity

        <JsonProperty("cost_price")>
        Public Property CostPrice As Integer

        <JsonProperty("receipt_id" & vbTab)>
        Public Property ReceiptId As String

        <JsonProperty("goods_detail")>
        Public Property GoodsDetail As List(Of GoodsDetailItemEntity)
    End Class

    Public Class GoodsDetailItemEntity
        Inherits BaseEntity

        <JsonProperty("goods_id")>
        Public Property GoodsId As String

        <JsonProperty("goods_name")>
        Public Property GoodsName As String

        <JsonProperty("quantity")>
        Public Property Quantity As Integer

        <JsonProperty("price")>
        Public Property Price As Integer
    End Class

    Public Class AlipayExtendParamsEntity
        Inherits BaseEntity

        <JsonProperty("hb_fq_instalment")>
        Public Property HbFqInstalment As Integer?

        <JsonProperty("hb_fq_num")>
        Public Property HbFqNum As Integer?

        <JsonProperty("hb_fq_seller_percent")>
        Public Property HbFqSellerPercent As Integer?
    End Class

    Public Class APaymentItemEntity
        Inherits BaseEntity

        <JsonProperty("type")>
        Public Property Type As String

        <JsonProperty("amount")>
        Public Property Amount As Decimal
    End Class


    Public Class ASignPackageEntity
        Inherits BaseEntity

        <JsonProperty("appId")>
        Public Property AppId As String

        <JsonProperty("timeStamp")>
        Public Property TimeStamp As String

        <JsonProperty("nonceStr")>
        Public Property NonceStr As String

        <JsonProperty("package")>
        Public Property Package As String

        <JsonProperty("signType")>
        Public Property SignType As String

        <JsonProperty("paySign")>
        Public Property PaySign As String
    End Class
End Namespace
