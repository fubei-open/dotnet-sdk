Imports Com.Fubei.Api.OpenApi.Biz.V1.Model.Request
Imports Com.Fubei.Api.OpenApi.Biz.V1.Model.Response
Imports Com.Illuminati.Galileo.Attr

Namespace Biz.V1
    ' 开放平台1.0接口，对应文档
    ' http://docs.51fubei.com/open-api/
    Public Partial Interface IFubeiMerchantApi

        ' 付款码支付
        <MerchantApi(Method:="openapi.payment.order.swipe")>
        Function OrderSwipe(<JsonObjectParam> ByVal param As OrderPayParam) As OrderPayResultEntity

        ' 扫码支付
        <MerchantApi(Method:="openapi.payment.order.scan")>
        Function OrderScan(<JsonObjectParam> ByVal param As OrderScanParam) As OrderScanResultEntity

        ' 订单查询
        <MerchantApi(Method:="openapi.payment.order.query")>
        Function OrderQuery(<JsonObjectParam> ByVal param As OrderQueryParam) As OrderQueryEntity
    End Interface

End Namespace
