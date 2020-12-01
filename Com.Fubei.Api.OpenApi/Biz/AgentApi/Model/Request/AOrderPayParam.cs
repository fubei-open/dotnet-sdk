using System;
using System.Collections.Generic;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Request
{
    /// <summary>
    /// 付款码支付
    /// 该接口支持服务商级和商户级接入。
    /// http://docs.51fubei.com/agent-api/payment/orderPay.html
    /// </summary>
    public class AOrderPayParam : BaseEntity
    {
        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }

        [JsonProperty("merchant_id")]
        public int? MerchantId { get; set; }

        [JsonProperty("auth_code")]
        public string AuthCode { get; set; }

        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("store_id")]
        public int? StoreId { get; set; }

        [JsonProperty("cashier_id")]
        public int? CashierId { get; set; }

        [JsonProperty("sub_appid")]
        public string SubAppId { get; set; }

        [JsonProperty("goods_tag")]
        public string GoodsTag { get; set; }

        [JsonProperty("detail")]
        public GoodsDetailEntity Detail { get; set; }

        [JsonProperty("device_no")]
        public string DeviceNo { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("attach")]
        public string Attach { get; set; }

        [JsonIgnore]
        public string TimeoutExpire
        {
            get => TimeoutExpress;
            set => TimeoutExpress = value;
        }

        [JsonProperty("timeout_express")]
        public string TimeoutExpress { get; set; }
        
        [JsonProperty("notify_url")]
        public string NotifyUrl { get; set; }

        [JsonProperty("alipay_extend_params")]
        public AlipayExtendParamsEntity AlipayExtendParams { get; set; }
    }
}
