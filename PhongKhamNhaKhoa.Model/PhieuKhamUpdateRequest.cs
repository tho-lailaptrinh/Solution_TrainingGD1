using PhongKhamNhaKhoa.Enum;
using System;

namespace PhongKhamNhaKhoa.Model
{
    public class PhieuKhamUpdateRequest
    {
        public string Name { get; set; }
        public Guid? IdDichVu { get; set; }
        public Guid? IdKhachHang { get; set; }
        public Guid? IdPhongKham { get; set; }
        public Guid? IdNhanVien { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
    }
}
