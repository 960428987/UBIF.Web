using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBIF.Web
{
    //[AttributeUsage(AttributeTargets.Method)]
    //public class HandlerAjaxOnlyAttribute : ActionMethodSelectorAttribute
    //{
    //    public bool Ignore { get; set; }
    //    public HandlerAjaxOnlyAttribute(bool ignore = false)
    //    {
    //        Ignore = ignore;
    //    }
    //    public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
    //    {
    //        if (Ignore)
    //            return true;
    //        return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
    //    }
    //}
}
