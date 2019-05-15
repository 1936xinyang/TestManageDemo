using Eds.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;

namespace WebApi.Core.Auth
{
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //如果用户使用了forms authentication，就不必在做basic authentication了
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return;
            }

            var url = actionContext.Request.RequestUri.AbsoluteUri;      
            var secretUrl = url.Split(new string[] { "key=" }, StringSplitOptions.RemoveEmptyEntries)[0].TrimEnd('&');
            if (url.Contains('?'))
            {
                var queryValue = url.Split('?')[1];
                if (!string.IsNullOrEmpty(queryValue) && !string.IsNullOrEmpty(secretUrl))
                {
                    var key = "";
                    var values = queryValue.Split('&');
                    foreach (var item in values)
                    {
                        var keyValue = item.Split('=');
                        if (keyValue[0] == "key")
                        {
                            key = keyValue[1];
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(key) && key == EncryptUtil.GetEncryptKey(secretUrl))
                    {
                        return;
                    }
                }
            }



            HandleUnauthorizedRequest(actionContext);
        }

        private void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "访问未经授权！", "application/json");
        }
    }
}