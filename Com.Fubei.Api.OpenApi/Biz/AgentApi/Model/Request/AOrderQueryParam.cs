using System;
using System.Collections.Generic;
using System.Text;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Request
{
    public class AOrderQueryParam : BaseEntity
    {
        [JsonProperty("merchant_id")]
        public int? MerchantId { get; set; }

        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }

        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }

        [JsonProperty("ins_order_sn")]
        public string InsOrderSn { get; set; }
    }
}
