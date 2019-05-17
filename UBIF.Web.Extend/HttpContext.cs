using Microsoft.AspNetCore.Http;
using System;

namespace UBIF.Web.Extend
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _accessor;
        public static Microsoft.AspNetCore.Http.HttpContext Current => _accessor.HttpContext;
        internal static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
}
