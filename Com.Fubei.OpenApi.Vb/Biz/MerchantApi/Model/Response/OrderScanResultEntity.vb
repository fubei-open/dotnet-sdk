Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json

Namespace Biz.V1.Model.Response
    Public Class OrderScanResultEntity
        Inherits BaseEntity

        <JsonProperty("order_sn")>
        Public Property OrderSn As String

        <JsonProperty("trade_no")>
        Public Property TradeNo As String

        <JsonProperty("qr_code")>
        Public Property QrCode As String

        <JsonProperty("store_id")>
        Public Property StoreId As Integer

        <JsonProperty("cashier_id")>
        Public Property CashierId As Integer?

        <JsonProperty("user_id")>
        Public Property UserId As String
    End Class
End Namespace
