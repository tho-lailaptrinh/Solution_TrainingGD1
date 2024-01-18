using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhongKhamNhaKhoa.Api.Entitis;

namespace PhongKhamNhaKhoa.Api.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        }
    }
}
