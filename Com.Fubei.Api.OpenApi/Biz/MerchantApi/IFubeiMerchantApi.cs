using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Request;
using Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Response;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Biz.MerchantApi.Model.Request;
using Com.Illuminati.Galileo.Biz.MerchantApi.Model.Response;

namespace Com.Illuminati.Galileo.Biz.MerchantApi
{
    /// <summary>
    /// 商户API接口
    /// </summary>
    public partial interface IFubeiMerchantApi
    {
        [MerchantApi(Method = "openapi.payment.order.swipe")]
        OrderPayResultEntity OrderSwipe([JsonObjectParam]OrderPayParam param);

        [MerchantApi(Method = "openapi.payment.order.scan")]
        OrderScanResultEntity OrderScan([JsonObjectParam] OrderScanParam param);

        [MerchantApi(Method = "openapi.payment.order.query")]
        OrderQueryEntity OrderQuery([JsonObjectParam] OrderQueryParam param);
    }
}
