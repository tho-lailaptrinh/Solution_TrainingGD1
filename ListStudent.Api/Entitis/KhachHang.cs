using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class KhachHang
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int? NumberPhone { get; set; }
        public string? AddressKH { get; set; }
        public virtual ICollection<PhieuKham>? PhieuKhams { get; set; }


    }
}
