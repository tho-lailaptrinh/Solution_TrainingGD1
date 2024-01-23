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
        //public DbSet<ImageFile> ImageFiles { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhieuKhamConfiguration());
           // modelBuilder.ApplyConfiguration(new KhachHangConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
