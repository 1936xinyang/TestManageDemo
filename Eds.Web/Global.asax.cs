using Eds.Web.Configs;
using Eds.Web.DAL;
using Eds.Web.Entities;
using Eds.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Eds.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var context = new MyEntity())
            {
                var sysUsers = new List<SysUser>
            {
                new SysUser{ UserName="tom", Email="tom@126.com",Password="1"},
                new SysUser{ UserName="martin", Email="martin@126.com",Password="2"},
            };
                sysUsers.ForEach(s => context.SysUsers.Add(s));
                context.SaveChanges();
                var sysRoles = new List<SysRole>
            {
                new SysRole{ RoleName="administrator",RoleDesc="full authorization"},
                new SysRole{ RoleName="guest",RoleDesc="can access the share data"}
            };
                sysRoles.ForEach(s => context.SysRoles.Add(s));
                context.SaveChanges();
            };
            //注册AutoMapper配置文件
            AutoMapperConfig.RegisterMappings();

        }
    }
}
