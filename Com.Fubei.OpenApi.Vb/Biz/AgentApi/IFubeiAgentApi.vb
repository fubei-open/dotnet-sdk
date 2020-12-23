Imports Com.Fubei.Api.OpenApi.Biz.V2.Model.Request
Imports Com.Fubei.Api.OpenApi.Biz.V2.Model.Response
Imports Com.Illuminati.Galileo.Attr

Namespace Biz.V2
    ' 开放平台2.0接口，对应文档
    ' http://docs.51fubei.com/agent-api/
    Public Partial Interface IFubeiAgentApi

        ' 付款码支付（刷卡支付）
        ' http://docs.51fubei.com/agent-api/payment/orderPay.html
        <AgentApi(Method:="fbpay.order.pay")>
        Function OrderPay(<JsonObjectParam> ByVal param As AOrderPayParam) As AOrderPayResultEntity

        ' 统一下单
        ' http://docs.51fubei.com/agent-api/payment/orderCreate.html
        <AgentApi(Method:="fbpay.order.create")>
        Function OrderCreate(<JsonObjectParam> ByVal param As AOrderCreateParam) As AOrderCreateResultEntity

        ' 订单查询
        ' http://docs.51fubei.com/agent-api/payment/orderQuery.html
        <AgentApi(Method:="fbpay.order.query")>
        Function OrderQuery(<JsonObjectParam> ByVal param As AOrderQueryParam) As AOrderQueryResultEntity

        ' 聚合码支付
        ' http://docs.51fubei.com/agent-api/payment/qrCodePay.html
        <AgentApi(Method:="fbpay.fixed.qrcode.create")>
        Function CreateFixedQrcode(<JsonObjectParam> ByVal param As ACreateFixedQrCodeParam) As ACreateFixedQrcodeResultEntity

        ' 订单撤销
        ' http://docs.51fubei.com/agent-api/payment/orderCancel.html
        <AgentApi(Method:="fbpay.order.cancel")>
        Function OrderCancel(<JsonObjectParam> ByVal param As AOrderClosureParam) As AOrderClosureResultEntity

        ' 订单关闭
        ' http://docs.51fubei.com/agent-api/payment/orderClose.html
        <AgentApi(Method:="fbpay.order.close")>
        Function OrderClose(<JsonObjectParam> ByVal param As AOrderClosureParam) As AOrderClosureResultEntity

        ' 订单退款
        ' http://docs.51fubei.com/agent-api/payment/orderRefund.html
        <AgentApi(Method:="fbpay.order.refund")>
        Function OrderRefund(<JsonObjectParam> ByVal param As ARefundOrderParam) As ARefundOrderResultEntity

        ' 退款订单查询
        ' http://docs.51fubei.com/agent-api/payment/orderRefundQuery.html
        <AgentApi(Method:="fbpay.order.refund.query")>
        Function OrderRefundQuery(<JsonObjectParam> ByVal param As AQueryRefundParam) As ARefundOrderResultEntity
    End Interface

End Namespace
