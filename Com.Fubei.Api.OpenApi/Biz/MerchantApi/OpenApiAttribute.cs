﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Illuminati.Galileo.Attr;
using Com.Illuminati.Galileo.Constants;

namespace Com.Illuminati.Galileo.Biz.MerchantApi
{
    public class MerchantApiAttribute : PostApiAttribute
    {
        public MerchantApiAttribute()
        {
            Path = "/gateway";
            Category = GalileoApiConfig.Category.MerchantApi;
        }
    }
}
