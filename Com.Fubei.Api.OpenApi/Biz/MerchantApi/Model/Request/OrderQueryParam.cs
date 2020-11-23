using System;
using System.Collections.Generic;
using System.Text;
using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Request
{
    public class OrderQueryParam : BaseEntity
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }

        /// <summary>
        /// 付呗订单号
        /// </summary>
        [JsonProperty("order_sn")] 
        public string OrderSn { get; set; }


        /// <summary>
        /// 设备终端号
        /// </summary>
        [JsonProperty("device_no")]
        public string DeviceNo { get; set; }
    }
}
