using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Response
{
    public class ARefundOrderEntity : BaseEntity
    {
        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }

        [JsonProperty("refund_sn")]
        public string RefundSn { get; set; }

        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }

        [JsonProperty("merchant_refund_sn")]
        public string MerchantRefundSn { get; set; }

        [JsonProperty("refund_amount")]
        public decimal RefundAmount { get; set; }

        [JsonProperty("refund_status")]
        public string RefundStatus { get; set; }

        [JsonProperty("finish_time")]
        public string FinishTime { get; set; }

        [JsonProperty("handler")]
        public int? Handler { get; set; }
    }
}
