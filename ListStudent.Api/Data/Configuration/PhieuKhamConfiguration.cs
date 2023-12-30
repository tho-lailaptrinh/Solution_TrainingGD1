using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhongKhamNhaKhoa.Api.Entitis;

namespace PhongKhamNhaKhoa.Api.Data.Configuration
{
    public class PhieuKhamConfiguration : IEntityTypeConfiguration<PhieuKham>
    {
        public void Configure(EntityTypeBuilder<PhieuKham> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.KhachHang).WithMany(y => y.PhieuKhams).HasForeignKey(x => x.IdKhachHang);
            builder.HasOne(x => x.DichVus).WithMany(y => y.PhieuKhams).HasForeignKey(x => x.IdDichVu);
            builder.HasOne(x => x.NhanViens).WithMany(y => y.PhieuKhams).HasForeignKey(x => x.IdNhanVien);
            builder.HasOne(x => x.PhongKham).WithMany(y => y.PhieuKhams).HasForeignKey(x => x.IdPhongKham);
        }
    }
}
