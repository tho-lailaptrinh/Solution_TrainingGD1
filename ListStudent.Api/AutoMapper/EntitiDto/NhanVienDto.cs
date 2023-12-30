using PhongKhamNhaKhoa.Enum;
using System;

namespace PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto
{
    public class NhanVienDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberPhone { get; set; }
        public string AddressNV { get; set; }
        public Position Position { get; set; }
        //public virtual PhieuKhamDto PhieuKham { get; set; }
    }
}
