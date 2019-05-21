using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UBIF.Web.Application.Infrastructure;
using UBIF.Web.Application.SystemSecurity;
using UBIF.Web.Application.SystemManage;
using UBIF.Web.Code;
using UBIF.Web.Data;
using UBIF.Web.Extend;
using UBIF.Web;
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
          
            //string loginController = "";
            //LogHelper.Info(loginController.GetType(), "测试info日志");
            //LogHelper.Debug(loginController.GetType(), "测试Debug日志");
            //LogHelper.Error(loginController.GetType(), "测试Error日志");
            //LogHelper.Fatal(loginController.GetType(), "测试Fatal日志");
            //LogHelper.Warn(loginController.GetType(), "测试Warn日志");
            //string sss = WebHelper.GetCookie("aaa");
            //WebHelper.WriteCookie("aaa","bbb");
            //string sssss = WebHelper.GetCookie("aaa");
            //string s =   Configs.GetValue("LoginProvider");
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            Licence.IsLicence("");
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        [HttpPost]
       // [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            SysLog logEntity = new SysLog();
            logEntity.FModuleName = "系统登录";
            logEntity.FType = DbLogType.Login.ToString();
            try
            {
                if (HttpContext.Session.GetString("ubif_session_verifycode").IsEmpty() || Md5.md5(code.ToLower(), 16) != HttpContext.Session.GetString("ubif_session_verifycode").ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                SysUser userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.FId;
                    operatorModel.UserCode = userEntity.FAccount;
                    operatorModel.UserName = userEntity.FRealName;
                    operatorModel.CompanyId = userEntity.FOrganizeId;
                    operatorModel.DepartmentId = userEntity.FDepartmentId;
                    operatorModel.RoleId = userEntity.FRoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.FAccount == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.FAccount = userEntity.FAccount;
                    logEntity.FNickName = userEntity.FRealName;
                    logEntity.FResult = true;
                    logEntity.FDescription = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.FAccount = username;
                logEntity.FNickName = username;
                logEntity.FResult = false;
                logEntity.FDescription = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }

        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new SysLog
            {
                FModuleName = "系统登录",
                FType = DbLogType.Exit.ToString(),
                FAccount = OperatorProvider.Provider.GetCurrent().UserCode,
                FNickName = OperatorProvider.Provider.GetCurrent().UserName,
                FResult = true,
                FDescription = "安全退出系统",
            });
            HttpContext.Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
    }
}