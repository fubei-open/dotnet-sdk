using System;
using System.Collections.Generic;
using System.Text;
using Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Request;
using Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Response;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Biz.MerchantApi;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi
{
    /// <summary>
    /// 付呗开放平台2.0接口
    /// </summary>
    public interface IFubeiAgentApi
    {
        [AgentApi(Method = "fbpay.order.pay")]
        AOrderPayResultEntity OrderPay([JsonObjectParam] AOrderPayParam param);

        [AgentApi(Method = "fbpay.order.query")]
        AOrderQueryResultEntity OrderQuery([JsonObjectParam] AOrderQueryParam param);

        [AgentApi(Method = "fbpay.fixed.qrcode.create")]
        ACreateFixedQrcodeResultEntity CreateFixedQrcode([JsonObjectParam] ACreateFixedQrCodeParam param);
    }
}
