using PhongKhamNhaKhoa.Enum;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class PhieuKham
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? IdDichVu { get; set; }
        public Guid? IdKhachHang { get; set; }
        public Guid? IdPhongKham { get; set; }
        public Guid? IdNhanVien {  get; set; }
        public DateTime? CreateDate { get; set; }
        public Status Status { get; set; }
        public virtual KhachHang? KhachHang { get; set;}
        public virtual DichVu? DichVus { get; set; }
        public virtual PhongKham? PhongKham { get; set; }
        public virtual NhanVien? NhanViens { get; set; }

    }
}
