using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Eds.Web.Controllers
{
    /// <summary>
    /// 登录授权筛选器类，继承于AuthorizeAttribute
    /// </summary>
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 验证用户是否登录
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;
            if (context.Session["SK_LOGININFO"] == null)
            {
                context.Response.Write("<script languge='javascript'>alert('登录超时,请重新登录！');if (window.location.href.indexOf('Login') >= 0) {window.location.href = '/Login/Index';    }else {window.location.href = '/Login/Index?returnUrl=' + encodeURIComponent(window.location.href);    }</script>");
            }
        }
    }
}
