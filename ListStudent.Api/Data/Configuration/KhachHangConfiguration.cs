using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhongKhamNhaKhoa.Api.Entitis;

namespace PhongKhamNhaKhoa.Api.Data.Configuration
{
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ImageFiles)?.WithMany(x => x.KhachHangs).HasForeignKey(x => x.IdImage);
        }
    }
}
