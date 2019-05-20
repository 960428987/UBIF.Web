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
