namespace Eds.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EdsDbContext : DbContext
    {
        public EdsDbContext()
            : base("name=EdsDbConn")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.Role)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.UserInfo)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete();
        }
    }
}
