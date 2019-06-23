using Eds.Web.Entities;
using Eds.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eds.Web.DAL
{
    public class MyEntityInitializer : DropCreateDatabaseAlways<MyEntity>
    {

        protected override void Seed(MyEntity context)
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
        }
    }
}