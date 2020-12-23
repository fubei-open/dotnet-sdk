using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Response
{
    public class ACreateFixedQrcodeResultEntity
    {
        [JsonProperty("qrcode_url")]
        public string QrcodeUrl { get; set; }

        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }
    }
}
