/*******************************************************************************
 * Copyright © 2016 UBIF.Web.Framework 版权所有
 * Author: UBIF.Web
 * Description: UBIF.Web快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBIF.Web.Code
{
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Cache();
        }
    }
}
