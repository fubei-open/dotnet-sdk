Imports Com.Fubei.Api.OpenApi.Biz.V2.Model.Request
Imports Com.Fubei.Api.OpenApi.Biz.V2.Model.Response
Imports Com.Illuminati.Galileo.Attr

Namespace Biz.V2
    ' 开放平台2.0接口，对应文档
    ' http://docs.51fubei.com/agent-api/
    Public Partial Interface IFubeiAgentApi

        <AgentApi(Method:="fbpay.order.pay")>
        Function OrderPay(<JsonObjectParam> ByVal param As AOrderPayParam) As AOrderPayResultEntity

        <AgentApi(Method:="fbpay.order.query")>
        Function OrderQuery(<JsonObjectParam> ByVal param As AOrderQueryParam) As AOrderQueryResultEntity

        <AgentApi(Method:="fbpay.fixed.qrcode.create")>
        Function CreateFixedQrcode(<JsonObjectParam> ByVal param As ACreateFixedQrCodeParam) As ACreateFixedQrcodeResultEntity
    End Interface

End Namespace
