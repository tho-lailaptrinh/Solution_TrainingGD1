using PhongKhamNhaKhoa.Enum;
using PhongKhamNhaKhoa.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class KhachHang
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public Guid? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User Users { get; set; }


        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [StringLength(10)]
        public string? NumberPhone { get; set; }
        public string? AddressKH { get; set; }
        public StatusKH StatusKH { get; set; }
        public virtual ICollection<PhieuKham> PhieuKhams { get; set; }
        public Guid? IdImage { get; set; }

        public virtual ImageFile ImageFiles { get; set; }
    }
}
