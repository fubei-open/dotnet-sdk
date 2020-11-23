using Com.Illuminati.Galileo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Request
{
    public class OrderScanParam : BaseEntity
    {
        /// <summary>
        /// 第三方商户的订单号,确保唯一，前后不允许带空格
        /// </summary>
        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }

        /// <summary>
        /// 支付方式：1微信/2支付宝
        /// </summary>
        [JsonProperty("type")] 
        public int Type { get; set; }

        /// <summary>
        /// 订单金额（元），精确到两位小数
        /// </summary>
        [JsonProperty("total_fee")] 
        public decimal TotalFee { get; set; }

        /// <summary>
        /// 门店Id，当存在多个门店时，此字段必填
        /// </summary>
        [JsonProperty("store_id")] 
        public int? StoreId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cashier_id")] 
        public int? CashierId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("device_no")] 
        public string DeviceNo { get; set; }

        /// <summary>
        /// 对交易或商品的描述（微信上body值显示在商品，支付宝上body值显示在商品说明）
        /// </summary>
        [JsonProperty("body")] 
        public string Body { get; set; }

        /// <summary>
        /// 支付成功后回调链接
        /// </summary>
        [JsonProperty("call_back_url")] 
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 硬件类型(90-127) ,非约定情况下该参数不需要传
        /// </summary>
        [JsonProperty("equipment_type")] 
        public int? EquipmentType { get; set; }

        /// <summary>
        /// 附加字段
        /// </summary>
        [JsonProperty("attach")] 
        public string Attach { get; set; }

        /// <summary>
        /// 订单优惠标记，代金券或立减优惠功能的参数【若为单品券则必填】
        /// </summary>
        [JsonProperty("goods_tag")] 
        public string GoodsTag { get; set; }

        [JsonProperty("sub_appid")] 
        public string SubAppId { get; set; }

        [JsonProperty("detail")] 
        public object Detail { get; set; }
    }
}
