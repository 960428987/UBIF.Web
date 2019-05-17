using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UBIF.Web.Code;
using UBIF.Web.Extend;
namespace UBIF.Web.Controllers
{
    public class LoginController : Controller
    {
        /*
         说明文档
         1、获取配置文件   string s =   Configs.GetValue("LoginProvider");
         2、HttpContext.Current.Request
         3、使用session   HttpContext.Session.SetString("code", "123456");
            HttpContext.Session.GetString("code");
        4、使用cookie 
         HttpContext.Response.Cookies.Append("getCookie", "setCookieValue");
            string getCookie = "";
            HttpContext.Request.Cookies.TryGetValue("getCookie", out getCookie);
             
             */
        public IActionResult Index()
        {
          
            string s =   Configs.GetValue("LoginProvider");
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            Licence.IsLicence("");
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
            return null;
        }
    }
}