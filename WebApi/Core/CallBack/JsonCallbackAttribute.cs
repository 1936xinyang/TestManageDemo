using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace WebApi.Core.CallBack
{
    public class JsonCallbackAttribute : ActionFilterAttribute
    {
        private const string CallbackQueryParameter = "callback";

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var callback = string.Empty;

            //Get
            if (IsJsonp(out callback))
            {
                var jsonBuilder = new StringBuilder(callback);

                jsonBuilder.AppendFormat("({0})", context.Response.Content.ReadAsStringAsync().Result);

                context.Response.Content = new StringContent(jsonBuilder.ToString());


            }
            else
            {
                if (context.Response.Content.GetType().FullName != "System.Net.Http.StreamContent")
                {
                    context.Response.Content = new StringContent(context.Response.Content.ReadAsStringAsync().Result);
                    //Post方式
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                }
            }

            base.OnActionExecuted(context);
        }

        private bool IsJsonp(out string callback)
        {
            callback = System.Web.HttpContext.Current.Request.QueryString[CallbackQueryParameter];

            return !string.IsNullOrEmpty(callback);
        }

    }
}