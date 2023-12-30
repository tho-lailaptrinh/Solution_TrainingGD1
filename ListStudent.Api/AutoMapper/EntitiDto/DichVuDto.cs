using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PhongKhamNhaKhoa.Api.AutoMapper.EntitiDto
{
    public class DichVuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<PhieuKhamDto> PhieuKhams { get; set; }
    }
}
