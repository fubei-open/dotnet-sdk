using System;
using System.Collections.Generic;
using System.Text;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Response
{
    public class OrderScanResultEntity : BaseEntity
    {
        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }

        [JsonProperty("trade_no")]
        public string TradeNo { get; set; }

        [JsonProperty("qr_code")]
        public string QrCode { get; set; }

        [JsonProperty("store_id")]
        public int StoreId { get; set; }

        [JsonProperty("cashier_id")]
        public int? CashierId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
