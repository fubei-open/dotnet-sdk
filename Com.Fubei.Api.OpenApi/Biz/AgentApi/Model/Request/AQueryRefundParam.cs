using System;
using System.Collections.Generic;
using System.Text;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Request
{
    /// <summary>
    /// 退款查询
    /// </summary>
    public class AQueryRefundParam : BaseEntity
    {
        [JsonProperty("merchant_id")]
        public int? MerchantId { get; set; }

        [JsonProperty("refund_sn")]
        public string RefundSn { get; set; }

        [JsonProperty("merchant_refund_sn")]
        public string MerchantRefundSn { get; set; }
    }
}
