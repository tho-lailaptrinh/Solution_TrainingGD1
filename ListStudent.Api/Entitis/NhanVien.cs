using PhongKhamNhaKhoa.Enum;
using System;
using System.Collections.Generic;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberPhone { get; set; }
        public string AddressNV { get; set; }
        public Position? Position { get; set; } // Chức vụ
        public virtual ICollection<PhieuKham>? PhieuKhams { get; set; }
    }
}
