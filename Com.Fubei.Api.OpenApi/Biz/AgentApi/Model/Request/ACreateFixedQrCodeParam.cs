using System;
using System.Collections.Generic;
using System.Text;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Request
{
    /// <summary>
    /// 聚合码支付
    /// http://docs.51fubei.com/agent-api/payment/qrCodePay.html
    /// </summary>
    public class ACreateFixedQrCodeParam : BaseEntity
    {
        [JsonProperty("merchant_id")]
        public int? MerchantId { get; set; }

        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }

        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("store_id")]
        public int StoreId { get; set; }

        [JsonProperty("sub_appid")]
        public string SubAppId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

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

        [JsonProperty("timeout_express")]
        public string TimeoutExpress { get; set; }

        [JsonProperty("notify_url")]
        public string NotifyUrl { get; set; }

        [JsonProperty("alipay_extend_params")]
        public AlipayExtendParamsEntity AlipayExtendParams { get; set; }

        [JsonProperty("expired_time")]
        public int ExpiredTime { get; set; } = 600;
    }
}
