using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using PhongKhamNhaKhoa.Model.Enum;

namespace PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto
{
    public class KhachHangDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string AddressKH { get; set; }
        public StatusKH StatusKH { get; set; }
        //public virtual ICollection<PhieuKhamDto> PhieuKhams { get; set; }

    }
}
