using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo;
using Com.Illuminati.Galileo.Attr;

namespace Com.Fubei.Api.OpenApi.Biz
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
