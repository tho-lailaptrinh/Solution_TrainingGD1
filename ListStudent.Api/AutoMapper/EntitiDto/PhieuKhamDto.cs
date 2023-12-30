using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Enum;
using System.Collections.Generic;
using System;

namespace PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto
{
    public class PhieuKhamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameKH { get; set; }
        public string NameNV { get; set; }
        public string NameDV { get; set; }
        public string NamePK { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
        //public virtual KhachHang KhachHang { get; set; }
        //public virtual DichVu DichVus { get; set; }
        //public virtual PhongKham PhongKham { get; set; }
        //public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
