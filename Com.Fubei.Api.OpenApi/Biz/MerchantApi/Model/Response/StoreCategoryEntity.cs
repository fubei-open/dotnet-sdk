using Com.Illuminati.Galileo.Model;
using Newtonsoft.Json;

namespace Com.Fubei.Api.OpenApi.Biz.MerchantApi.Model.Response
{
    /// <summary>
    /// http://docs.51fubei.com/open-api/business/methods/storeCategory.html
    /// </summary>
    public class StoreCategoryEntity : BaseEntity
    {
        [JsonProperty("category_id")]
        public int Id { get; set; }

        [JsonProperty("category_name")]
        public string Category { get; set; }
    }
}
