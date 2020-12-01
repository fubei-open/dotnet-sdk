using System;
using System.Collections.Generic;
using System.Text;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.AgentApi.Model
{
    // 以下为扩展参数
    #region 商品详情
    public class GoodsDetailEntity : BaseEntity
    {
        [JsonProperty("cost_price")]
        public int CostPrice { get; set; }

        [JsonProperty("receipt_id	")]
        public string ReceiptId { get; set; }

        [JsonProperty("goods_detail")]
        public List<GoodsDetailItemEntity> GoodsDetail { get; set; }
    }

    public class GoodsDetailItemEntity : BaseEntity
    {
        [JsonProperty("goods_id")]
        public string GoodsId { get; set; }

        [JsonProperty("goods_name")]
        public string GoodsName { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }
    #endregion

    #region 支付宝-花呗分期业务扩展

    public class AlipayExtendParamsEntity : BaseEntity
    {
        [JsonProperty("hb_fq_instalment")]
        public int? HbFqInstalment { get; set; }

        [JsonProperty("hb_fq_num")]
        public int? HbFqNum { get; set; }

        [JsonProperty("hb_fq_seller_percent")]
        public int? HbFqSellerPercent { get; set; }
    }

    #endregion

    #region 活动优惠列表
    public class APaymentItemEntity : BaseEntity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
    #endregion
}
