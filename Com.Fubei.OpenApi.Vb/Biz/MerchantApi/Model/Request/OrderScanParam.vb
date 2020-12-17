Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V1.Model.Request
    Public Class OrderScanParam
        Inherits BaseEntity

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

        <JsonProperty("type")>
        Public Property Type As Integer

        <JsonProperty("total_fee")>
        Public Property TotalFee As Decimal

        <JsonProperty("store_id")>
        Public Property StoreId As Integer?

        <JsonProperty("cashier_id")>
        Public Property CashierId As Integer?

        <JsonProperty("device_no")>
        Public Property DeviceNo As String

        <JsonProperty("body")>
        Public Property Body As String

        <JsonProperty("call_back_url")>
        Public Property CallbackUrl As String

        <JsonProperty("equipment_type")>
        Public Property EquipmentType As Integer?

        <JsonProperty("attach")>
        Public Property Attach As String

        <JsonProperty("goods_tag")>
        Public Property GoodsTag As String

        <JsonProperty("sub_appid")>
        Public Property SubAppId As String

        <JsonProperty("detail")>
        Public Property Detail As Object
    End Class
End Namespace
