
Imports Com.Illuminati.Galileo.Model
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Biz.V2.Model.Response
    Public Class AOrderCreateResultEntity
        Inherits BaseEntity

		<JsonProperty("order_sn")>
        Public Property OrderSn As String

		<JsonProperty("merchant_order_sn")>
        Public Property MerchantOrderSn As String

		<JsonProperty("prepay_id")>
        Public Property PrepayId As String

		<JsonProperty("pay_type")>
        Public Property PayType As String

		<JsonProperty("total_amount")>
        Public Property TotalAmount As String

		<JsonProperty("store_id")>
        Public Property StoreId As Integer

		<JsonProperty("cashier_id")>
        Public Property CashierId As Integer

		<JsonProperty("user_id")>
        Public Property UserId As String

		<JsonProperty("device_no")>
        Public Property DeviceNo As String

		<JsonProperty("attach")>
        Public Property Attach As String

		<JsonProperty("sign_package")>
        Public Property SignPackage As ASignPackageEntity
    End Class
End Namespace