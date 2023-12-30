using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class DichVu
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Money { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public virtual ICollection<PhieuKham>? PhieuKhams { get; set; }
    }
}
