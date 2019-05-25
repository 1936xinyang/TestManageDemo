using System.Web.Http;
using System.Web.Http.Dependencies;
using WebApi.Core.Auth;
using WebApi.Core.Unity;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            /*
             将 Web API 配置为仅使用不记名令牌身份验证。
             SuppressDefaultHostAuthentication方法告知 Web API 忽略在请求到达 Web API 管道，IIS 或 OWIN 中间件之前发生的任何身份验证。 这样一来，我们可以限制只使用持有者令牌进行身份验证的 Web API
             */
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //配置Basic基础认证
            //config.Filters.Add(new BasicAuthorizeAttribute());

            //配置Unity依赖注入容器
            config.DependencyResolver = new UnityResolver(UnityConfig.GetConfiguredContainer());


            // Web API 路由
            config.MapHttpAttributeRoutes();
            //1.默认路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"\d*" } //约束，这个表示匹配0个或多个数字
                //constraints: new { id = @"\d+" }  //正则\d+表示匹配一个或多个数字
            );

            //2.自定义路由一：匹配到action
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "actionapi/{controller}/{action}/{id}",  //将路由模板的前缀改成了“actionapi”。
                defaults: new { id = RouteParameter.Optional }
            );

            //3.自定义路由二
            config.Routes.MapHttpRoute(
                name: "TestApi",
                routeTemplate: "testapi/{controller}/{ordertype}/{id}",
                defaults: new { ordertype = "aa", id = RouteParameter.Optional }//只要{ordertype}按照路由规则去配置，都能找到对应的方法。
            );
        }
    }
}
