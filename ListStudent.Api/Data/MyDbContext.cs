using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.Data.Configuration;
using PhongKhamNhaKhoa.Api.Entitis;

namespace PhongKhamNhaKhoa.Api.Data
{
    public class MyDbContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhieuKhamConfiguration());
        }

    }
}
