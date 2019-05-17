#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：UBIF.Web.Code.Configs
* 项目描述 ：
* 类 名 称 ：ConfigHelper
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：UBIF.Web.Code.Configs
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/5/17 17:25:51
* 更新时间 ：2019/5/17 17:25:51
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UBIF.Web.Extend
{
    public static class SiteConfig
    {
        //申明一个IConfigurationSection 类型变量
        private static IConfigurationSection _appSection = null;

        /// <summary>
        /// 静态方法获取到配置的Value项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSetting(string key)
        {
            string str = string.Empty;
            if (_appSection.GetSection(key) != null)
            {
                str = _appSection.GetSection(key).Value;
            }
            return str;
        }

        /// <summary>
        /// 设置IConfigurationSection初始值
        /// </summary>
        /// <param name="section"></param>
        public static void SetAppSetting(IConfigurationSection section)
        {
            _appSection = section;
        }

        /// <summary>
        /// 根据不同Json项读取出对应的值
        /// </summary>
        /// <param name="apiName"></param>
        /// <returns></returns>
        public static string GetSite(string apiName)
        {
            return AppSetting(apiName);
        }
    }
}
