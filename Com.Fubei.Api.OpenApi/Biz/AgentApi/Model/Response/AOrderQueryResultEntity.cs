using System;
using System.Collections.Generic;
using System.Text;
using Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Request;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model.Response
{
    public class AOrderQueryResultEntity : BaseEntity
    {
        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }

        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }

        [JsonProperty("ins_order_sn")]
        public string InsOrderSn { get; set; }

        [JsonProperty("channel_order_sn")]
        public string ChannelOrderSn { get; set; }

        [JsonProperty("order_status")]
        public string OrderStatus { get; set; }

        [JsonProperty("pay_type")]
        public string PayType { get; set; }

        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("net_amount")]
        public decimal? NetAmount { get; set; }

        [JsonProperty("buyer_pay_amount")]
        public decimal? BuyerPayAmount { get; set; }

        [JsonProperty("fee")]
        public decimal? Fee { get; set; }

        [JsonProperty("store_id")]
        public int StoreId { get; set; }

        [JsonProperty("cashier_id")]
        public int CashierId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("finish_time")]
        public string FinishTime { get; set; }

        [JsonProperty("device_no")]
        public string DeviceNo { get; set; }

        [JsonProperty("attach")]
        public string Attach { get; set; }

        [JsonProperty("payment_list")]
        public List<APaymentItemEntity> PaymentList { get; set; }

        [JsonProperty("alipay_extend_params")]
        public AlipayExtendParamsEntity AlipayExtendParams { get; set; }
    }
}
