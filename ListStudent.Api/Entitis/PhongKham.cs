using PhongKhamNhaKhoa.Api.Entitis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class PhongKham
    {
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public virtual ICollection<PhieuKham>? PhieuKhams { get; set; }
    }
}
