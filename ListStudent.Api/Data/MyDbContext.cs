using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.Data.Configuration;
using PhongKhamNhaKhoa.Api.Entitis;
using System;

namespace PhongKhamNhaKhoa.Api.Data
{
    public class MyDbContext : IdentityDbContext<User,Role,Guid>
    {   
        public MyDbContext()
        {
            
        }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PhieuKham> PhieuKhams { get; set;}
        public DbSet<KhachHang> KhachHangs { get; set;}   
        public DbSet<NhanVien> NhanViens { get; set;}
        public DbSet<PhongKham> PhongKhams { get; set;}
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhieuKhamConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogin").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserUserToken").HasKey(x => x.UserId);

        }
    }
}
