Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V1.Model.Request
    Public Class OrderPayParam
        Inherits BaseEntity

        <JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String
        
        <JsonProperty("type")>
        Public Property Type As Integer
       
        <JsonProperty("auth_code")>
        Public Property AuthCode As String
        
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
        Public Property CallBackUrl As String
        
        <JsonProperty("equipment_type")>
        Public Property EquipmentType As Integer?
        
        <JsonProperty("discount_switch")>
        Public Property DiscountSwitch As Integer?
        
        <JsonProperty("attach")>
        Public Property Attach As String
        
        <JsonProperty("goods_tag")>
        Public Property GoodsTag As String
        
        <JsonProperty("detail")>
        Public Property Detail As SwipeGoodDetailEntity
        
        <JsonProperty("sub_appid")>
        Public Property SubAppId As String
        
        <JsonProperty("timeout_express")>
        Public Property TimeoutExpress As String
       
        <JsonProperty("scene")>
        Public Property Scene As String
        
        <JsonProperty("buyer_id")>
        Public Property BuyerId As String

        Public Class GoodDetailEntity
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

        Public Class SwipeGoodDetailEntity
            Inherits BaseEntity

            <JsonProperty("cost_price")>
            Public Property CostPrice As Integer
            
            <JsonProperty("receipt_id")>
            Public Property ReceiptId As String
            
            <JsonProperty("goods_detail")>
            Public Property GoodsDetail As List(Of GoodDetailEntity)
        End Class

    End Class
End Namespace
