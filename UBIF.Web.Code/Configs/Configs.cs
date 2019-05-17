/*******************************************************************************
 * Copyright © 2016 UBIF.Web.Framework 版权所有
 * Author: UBIF.Web
 * Description: UBIF.Web快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using System.Configuration;
using System.Web;
using UBIF.Web.Extend;

namespace UBIF.Web.Code
{
    public class Configs
    {
        /// <summary>
        /// 根据Key取Value值
        /// </summary>
        /// <param name="key"></param>
        public static string GetValue(string key)
        {
            return SiteConfig.GetSite(key);
        }

    }
}
