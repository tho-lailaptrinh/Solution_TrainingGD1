using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto
{
    public class KhachHangDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberPhone { get; set; }
        public string AddressKH { get; set; }
        //public virtual ICollection<PhieuKhamDto> PhieuKhams { get; set; }

    }
}
