using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Constants;

namespace Com.Illuminati.Galileo.Biz.MerchantApi
{
    public class AgentApiAttribute : PostApiAttribute
    {
        public AgentApiAttribute()
        {
            Path = "/gateway/agent";
            Category = GalileoApiConfig.Category.AgentApi;
        }
    }
}
