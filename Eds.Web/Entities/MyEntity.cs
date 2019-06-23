namespace Eds.Web.Entities
{
    using Eds.Web.DAL;
    using Eds.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class MyEntity : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyEntity”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Eds.Web.Entities.MyEntity”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyEntity”
        //连接字符串。
        public MyEntity()
            : base("name=MyEntity")
        {
            Database.SetInitializer(new MyEntityInitializer());
        }

        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }

        public DbSet<SysUserRole> SysUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}